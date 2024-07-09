using Don_t_Starve.Equipments;
using Don_t_Starve.Map;
using Don_t_Starve.GameEngine;
using Don_t_Starve.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Entities
{
	class Player
	{
		private Dictionary<string, int> _resources = new Dictionary<string, int>();
		private int _maxInventory;
		private double _hp;
		private double _brain;
		private double _hunger;
		private double _thirst;
		private int _actionPoints;
		private bool _daytime;
		private string _name;
		private Dictionary<string, Equipment> _tools = new Dictionary<string, Equipment>();
		private FlowerWreath _flowerWreath;
		private List<Campfire> _campfires;
		private Position _position;
		private PlayerGameCoefficients _gameCoeffs;

		public Player(string name, int minCoord, int maxCoord, PlayerGameCoefficients playerGameCoefficients)
		{
			Random random = new Random();

			_name = name;
			_hp = 100.0;
			_brain = 100.0;
			_hunger = 100.0;
			_thirst = 100.0;
			_maxInventory = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(40);
			foreach (string collectible in Constants.Collectibles)
			{
				_resources[collectible] = 0;
			}
			foreach (string cookable in Constants.Bakeble)
			{
				_resources["baked_" + cookable] = 0;
			}
			_actionPoints = 75;
			_daytime = true;
			_tools[Constants.Axe] = null;
			_tools[Constants.Pickaxe] = null;
			_flowerWreath = null;
			_campfires = new List<Campfire>();
			_position = new Position(random.Next(minCoord, maxCoord), random.Next(minCoord, maxCoord));

			_gameCoeffs = playerGameCoefficients;
			
		}

		public double Hp { get => _hp; set => CheckLiveProperty(ref _hp, value); }
		public double Brain { get => _brain; set => CheckLiveProperty(ref _brain, value); }
		public double Hunger { get => _hunger; set => CheckLiveProperty(ref _hunger, value); }
		public double Thirst { get => _thirst; set => CheckLiveProperty(ref _thirst, value); }
		public int ActionPoints
		{
			get => _actionPoints;

			set
			{
				if (value == 0)
				{
					ChangePartOfTheDay();
				}
				else
				{
					_actionPoints = value;
				}
			}
		}
		public bool Daytime { get => _daytime; }
		public string Name { get => _name; }
		public Dictionary<string, int> Resources { get => _resources; }
		public FlowerWreath FlowerWreath { get => _flowerWreath;  }
		public List<Campfire> Campfires { get => _campfires; }
		public Dictionary<string, Equipment> Tools { get => _tools; }
		public Position Position { get => _position; }

		private void CheckLiveProperty (ref double property, double value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
			if (value >= 100.0)
			{
				property = 100.0;
			}
			else if (value <= 0.0)
			{
				throw new YouAreDeadException();
			}
			else
			{
				property = value;
			}
		}

		private T UseEquipment<T>(T equipment) where T : Equipment
		{
			if (equipment != null)
			{
				if (equipment.IsUsable())
				{
					equipment.Use();
					if (!equipment.IsUsable())
					{
						return null;
					}
				}
				else
				{
					throw new WrongActionException("This " + equipment.Name + " not usable anymore!");
				}
			}
			else
			{
				throw new WrongActionException("You have not the necessary equipment!");
			}

			return equipment;
		}

		private void ChangePartOfTheDay()
		{
			if (_daytime)
			{
				_actionPoints = 25;
				_daytime = false;
			}
			else
			{
				_actionPoints = 75;
				_daytime = true;
				
				if (_campfires.Count > 0)
				{
					for (int i = 0; i < _campfires.Count; i++)
					{
						Campfire campfire = UseEquipment(_campfires.ElementAt(i));
						if (campfire == null)
						{
							_campfires.RemoveAt(i);
							i--;
						}
					}
				}

				if (_flowerWreath != null)
				{
					_flowerWreath = UseEquipment(_flowerWreath);
				}
			}
		}

		private bool IsExistNearlyCampfire()
		{
			if (_campfires.Count > 0)
			{
				foreach (Campfire campfire in _campfires)
				{
					if (_gameCoeffs.MaxSafetyDistanceFromCampfire >= _position.GetDistance(campfire.Position))
					{
						return true;
					}
				}
			}

			return false;
		}

		private void SpendActionPoints(int spentActionPoints)
		{
			if (_actionPoints >= spentActionPoints)
			{
				ActionPoints -= spentActionPoints;
				Hunger -= _gameCoeffs.HungerLossByAction * spentActionPoints;
				if (!_daytime)
				{
					Thirst -= _gameCoeffs.ThirstLossByActionAtNight;
					if (IsExistNearlyCampfire())
					{
						Brain -= (_flowerWreath != null) ?
							((_gameCoeffs.BrainLossNight - _gameCoeffs.BrainGainWithFlowerWreath) * spentActionPoints) :
							(_gameCoeffs.BrainLossNight * spentActionPoints);
					}
					else
					{
						Brain -= _gameCoeffs.BrainLossNightWithoutCampfire;
						Hp -= _gameCoeffs.HpLossAtNightWithoutCampfire;
					}
					
				}
				else
				{
					Thirst -= _gameCoeffs.ThirstLossByActionAtDaytime;
				}
			}
			else
			{
				int remainedActionPoints = spentActionPoints - _actionPoints;
				SpendActionPoints(_actionPoints);
				SpendActionPoints(remainedActionPoints);
			}
		}

		private bool IsFreeInventorySpaceForResource(string resourceType)
		{
			if (_resources[resourceType] < _maxInventory)
			{
				return true;
			}
			else
			{
				throw new WrongActionException("No more " + resourceType + " can be stored!");
			}
		}

		public void CollectResource(string resourceType, int actionPoints)
		{
			if (IsFreeInventorySpaceForResource(resourceType))
			{
				_resources[resourceType]++;
				SpendActionPoints(actionPoints);
			}
		}

		public void CollectResource(string resourceType, int actionPoints, string toolName)
		{
			if (IsFreeInventorySpaceForResource(resourceType))
			{
				_tools[toolName] = UseEquipment(_tools[toolName]);
				CollectResource(resourceType, actionPoints);
			}
		}

		public void Wait()
		{
			SpendActionPoints(1);
		}

		public void CreateEquipment(Dictionary<string, int> rawMaterials, int spentActionPoints, string equipmentName)
		{
			foreach (string material in rawMaterials.Keys)
			{
				if (_resources[material] < rawMaterials[material])
				{
					throw new WrongActionException("Cannot be made " + equipmentName + ", because you have not enough " + material + "!");
				}
			}

			SpendActionPoints(spentActionPoints);
			foreach (string material in rawMaterials.Keys)
			{
				_resources[material] -= rawMaterials[material];
			}

			switch (equipmentName)
			{
				case Constants.Axe:
					_tools[Constants.Axe] = new Axe();
					break;
				case Constants.Pickaxe:
					_tools[Constants.Pickaxe] = new Pickaxe();
					break;
				case Constants.FlowerWreath:
					_flowerWreath = new FlowerWreath();
					break;
				case Constants.Campfire:
					Campfires.Add(new Campfire(_position));
					break;
				default:
					throw new Exception("Unknown equipment!");
			}
		}

		public void BakeFood(string food)
		{
			bool isBakeble = false;

			foreach (Campfire campfire in _campfires)
			{
				if (campfire.Position.Equals(_position))
				{
					isBakeble = true;
					break;
				}
			}

			if (isBakeble && _resources[food] > 0 && _resources["baked_" + food] < _maxInventory)
			{
				SpendActionPoints(1);
				_resources[food]--;
				_resources["baked_" + food]++;
			}
			else if (!isBakeble)
			{
				throw new WrongActionException("Wrong action! Please, go to a campfire to can bake a(n) " + food + "!");
			}
			else if (!(_resources[food] > 0))
			{
				throw new WrongActionException("Wrong action! You have not any" + food + "!");
			}
			else
			{
				throw new WrongActionException("Wrong action! You have not carry more baked (or cooked) " + food + "!");
			}

		}

		private void CheckDestinationWalkableAndUpdatePosition(Position newPosition, Field[,] map)
		{
			bool destinationIsReachable = false;

			for (int x = newPosition.XPosition - 1; x <= newPosition.XPosition + 1; x++)
			{
				for (int y = newPosition.YPosition - 1; y <= newPosition.YPosition; y++)
				{
					if (map[x, y].isWalkable())
					{
						destinationIsReachable = true;
					}
				}
			}

			if (destinationIsReachable)
			{
				_position = newPosition;
				SpendActionPoints(1);
			}
			else
			{
				throw new WrongActionException("The destination is impassable!");
			}
		}

		public void Move(string direction, Field[,] map)
		{
			switch (direction)
			{
				case Constants.Left:
					CheckDestinationWalkableAndUpdatePosition(new Position(_position.XPosition - 1, _position.YPosition), map);
					break;
				case Constants.Right:
					CheckDestinationWalkableAndUpdatePosition(new Position(_position.XPosition + 1, _position.YPosition), map);
					break;
				case Constants.Up:
					CheckDestinationWalkableAndUpdatePosition(new Position(_position.XPosition, _position.YPosition - 1), map);
					break;
				case Constants.Down:
					CheckDestinationWalkableAndUpdatePosition(new Position(_position.XPosition, _position.YPosition + 1), map);
					break;
				default:
					throw new WrongActionException("Unknown direction!");
			}
		}

		private bool CheckPlayerHasChoosedFood(string food)
		{
			if (_resources[food] > 0)
			{
				return true;
			}
			else
			{
				throw new WrongActionException("Wrong action! You have not any " + food.Replace('_', ' ') + "!");
			}
		}

		private void GetEatingEffects(double thirst, double hunger, double hp, double brain, string food)
		{
			_resources[food]--;
			Thirst += thirst;
			Hunger += hunger;
			Hp += hp;
			Brain += brain;
		}

		public void Eat(string food, bool isBaked)
		{
			if (isBaked)
			{
				if (CheckPlayerHasChoosedFood("baked_" + food))
				{
					switch (food)
					{
						case Constants.Water:
							GetEatingEffects(_gameCoeffs.GainThirstDrinkingBoiledWater, _gameCoeffs.GainHungerDrinkingBoiledWater, _gameCoeffs.GainHpDrinkingBoiledWater, _gameCoeffs.GainBrainDrinkingBoiledWater, "baked_" + food);
							break;
						case Constants.Herb:
							GetEatingEffects(_gameCoeffs.GainThirstEatingBakedHerb, _gameCoeffs.GainHungerEatingBakedHerb, _gameCoeffs.GainHpEatingBakedHerb, _gameCoeffs.GainBrainEatingBakedHerb, "baked_" + food);
							break;
						case Constants.Carrot:
							GetEatingEffects(_gameCoeffs.GainThirstEatingBakedCarrot, _gameCoeffs.GainHungerEatingBakedCarrot, _gameCoeffs.GainHpEatingBakedCarrot, _gameCoeffs.GainBrainEatingBakedCarrot, "baked_" + food);
							break;
						case Constants.Berry:
							GetEatingEffects(_gameCoeffs.GainThirstEatingBakedBerry, _gameCoeffs.GainHungerEatingBakedBerry, _gameCoeffs.GainHpEatingBakedBerry, _gameCoeffs.GainBrainEatingBakedBerry, "baked_" + food);
							break;
						default:
							throw new WrongActionException("Unknown food!");
					}
				}
			}
			else
			{
				if (CheckPlayerHasChoosedFood(food))
				{
					switch (food)
					{
						case Constants.Water:
							GetEatingEffects(_gameCoeffs.GainThirstDrinkingUnboiledWater, _gameCoeffs.GainHungerDrinkingUnboiledWater, _gameCoeffs.GainHpDrinkingUnboiledWater, _gameCoeffs.GainBrainDrinkingUnboiledWater, food);
							break;
						case Constants.Herb:
							GetEatingEffects(_gameCoeffs.GainThirstEatingUnbakedHerb, _gameCoeffs.GainHungerEatingUnbakedHerb, _gameCoeffs.GainHpEatingUnbakedHerb, _gameCoeffs.GainBrainEatingUnbakedHerb, food);
							break;
						case Constants.Carrot:
							GetEatingEffects(_gameCoeffs.GainThirstEatingUnbakedCarrot, _gameCoeffs.GainHungerEatingUnbakedCarrot, _gameCoeffs.GainHpEatingUnbakedCarrot, _gameCoeffs.GainBrainEatingUnbakedCarrot, food);
							break;
						case Constants.Berry:
							GetEatingEffects(_gameCoeffs.GainThirstEatingUnbakedBerry, _gameCoeffs.GainHungerEatingUnbakedBerry, _gameCoeffs.GainHpEatingUnbakedBerry, _gameCoeffs.GainBrainEatingUnbakedBerry, food);
							break;
						default:
							throw new WrongActionException("Unknown food!");
					}
				}
			}
		}
	}
}
