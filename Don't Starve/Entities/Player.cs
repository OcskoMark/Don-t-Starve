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
		private Axe _axe;
		private Pickaxe _pickaxe;
		private FlowerWreath _flowerWreath;
		private List<Campfire> _campfires;
		private Position _position;
		private GameCoefficients _gameCoefficients;

		public Player(string name, int minCoord, int maxCoord, GameCoefficients gameCoefficients)
		{
			Random random = new Random();

			_name = name;
			_hp = 100.0;
			_brain = 100.0;
			_hunger = 100.0;
			_thirst = 100.0;
			_maxInventory = GameCoefficients.DividedByDifficultyModifier(40);
			foreach (string collectible in Constants.collectibles)
			{
				_resources[collectible] = 0;
			}
			_actionPoints = 75;
			_daytime = true;
			_axe = null;
			_pickaxe = null;
			_flowerWreath = null;
			_campfires = new List<Campfire>();
			_position = new Position(random.Next(minCoord, maxCoord), random.Next(minCoord, maxCoord));

			_gameCoefficients = gameCoefficients;
			
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
		public Axe Axe { get => _axe; }
		public Pickaxe PickAxe { get => _pickaxe; }
		public FlowerWreath FlowerWreath { get => _flowerWreath;  }
		internal List<Campfire> Campfires { get => _campfires; set => _campfires = value; }

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

		private void UseEquipment<T>(ref T equipment) where T : Equipment
		{
			if (equipment != null)
			{
				if (equipment.IsUsable())
				{
					equipment.Use();
					if (!equipment.IsUsable())
					{
						equipment = null;
					}
				}
				else
				{
					throw new WrongActionException("This " + equipment.Name + " not usable anymore!");
				}
			}
			else
			{
				throw new WrongActionException("This equipment does not exist!");
			}
			
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
					for (int i = 0; i < Campfires.Count; i++)
					{
						Campfires.ElementAt(i).Use();
						if (!(Campfires.ElementAt(i).IsUsable()))
						{
							Campfires.RemoveAt(i);
							i--;
						}
					}
				}

				if (_flowerWreath != null)
				{
					UseEquipment(ref _flowerWreath);
				}
			}
		}

		private bool IsExistNearlyCampfire()
		{
			if (_campfires.Count > 0)
			{
				foreach (Campfire campfire in _campfires)
				{
					if (_gameCoefficients.MaxSafetyDistanceFromCampfire >= _position.GetDistance(campfire.Position))
					{
						return true;
					}
				}
			}

			return false;
		}

		private void DoAction(int spentActionPoints)
		{
			if (_actionPoints >= spentActionPoints)
			{
				ActionPoints -= spentActionPoints;
				Hunger -= _gameCoefficients.HungerLossByAction * spentActionPoints;
				if (!_daytime)
				{
					Thirst -= _gameCoefficients.ThirstLossByActionAtNight;
					if (IsExistNearlyCampfire())
					{
						Brain -= (_flowerWreath != null) ?
							((_gameCoefficients.BrainLossNight - _gameCoefficients.BrainGainWithFlowerWreath) * spentActionPoints) :
							(_gameCoefficients.BrainLossNight * spentActionPoints);
					}
					else
					{
						Brain -= _gameCoefficients.BrainLossNightWithoutCampfire;
						Hp -= _gameCoefficients.HpLossAtNightWithoutCampfire;
					}
					
				}
				else
				{
					Thirst -= _gameCoefficients.ThirstLossByActionAtDaytime;
				}
			}
			else
			{
				int remainedActionPoints = spentActionPoints - _actionPoints;
				DoAction(_actionPoints);
				DoAction(remainedActionPoints);
			}
		}

		public void CollectResource(string resourceType, int spentActionPoints, string equipmentName = "")
		{
			if (_resources[resourceType] < _maxInventory)
			{
				switch(equipmentName)
				{
					case Constants.Axe:
						UseEquipment(ref _axe);
						break;
					case Constants.Pickaxe:
						UseEquipment(ref _pickaxe);
						break;
				}
				_resources[resourceType]++;
				DoAction(spentActionPoints);
			}
			else
			{
				throw new WrongActionException("No more " + resourceType + " can be stored!");
			}
		}

		public void Wait()
		{
			DoAction(1);
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

			DoAction(spentActionPoints);
			foreach (string material in rawMaterials.Keys)
			{
				_resources[material] -= rawMaterials[material];
			}

			switch (equipmentName)
			{
				case Constants.Axe:
					_axe = new Axe();
					break;
				case Constants.Pickaxe:
					_pickaxe = new Pickaxe();
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
	}
}
