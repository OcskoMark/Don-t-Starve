using Don_t_Starve.Entities;
using Don_t_Starve.Equipments;
using Don_t_Starve.Exceptions;
using Don_t_Starve.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class Game
	{
		private const int OceanMinWidth = 15;

		private GameCoefficientsCalculatorSingleton _gameCoefficientsCalculator;
		private Player _player;
		private Field[,] _map;

		public Game(int mapSize, double difficultyModifier, string playerName)
		{
			_gameCoefficientsCalculator = GameCoefficientsCalculatorSingleton.GetInstance(difficultyModifier);
			_map = GenerateMap(mapSize);
			_player = new Player(playerName, OceanMinWidth, (mapSize + OceanMinWidth), new PlayerGameCoefficients());
			Play();
		}

		private Field[,] GenerateMap(int mapSize)
		{
			int increasedMapSize = mapSize + OceanMinWidth * 2;
			Field[,] map = new Field[increasedMapSize, increasedMapSize];

			FieldFactory fieldFactory = new FieldFactory();
			Random random = new Random();

			double probabilityOfEmptyLand = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier((mapSize * mapSize / 2.0)) / (mapSize * mapSize);

			int lastNonOceanCoord = increasedMapSize - OceanMinWidth;

			for (int row = 0; row < increasedMapSize; row++)
			{
				for (int column = 0; column < increasedMapSize; column++)
				{
					if (row < OceanMinWidth || row > lastNonOceanCoord || column < OceanMinWidth || column > lastNonOceanCoord)
					{
						map[row, column] = fieldFactory.CreateField(Constants.Water);
					}
					else if (map[row, column] == null)
					{
						if (random.NextDouble() < probabilityOfEmptyLand)
						{
							map[row, column] = fieldFactory.CreateField(Constants.Land);
						}
						else
						{
							double randomToOtherFields = random.NextDouble();

							if (randomToOtherFields < 0.3)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Tree);
							}
							else if (randomToOtherFields < 0.53)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Grass);
							}
							else if (randomToOtherFields < 0.75)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Bough);
							}
							else if (randomToOtherFields < 0.85)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Stone);
							}
							else if (randomToOtherFields < 0.94)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Flower);
							}
							else if (randomToOtherFields < 0.965)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Berry);
							}
							else if (randomToOtherFields < 0.982)
							{
								map[row, column] = fieldFactory.CreateField(Constants.Carrot);
							}
							else
							{
								map[row, column] = fieldFactory.CreateField(Constants.Herb);
							}
						}
					}
				}
			}

			return map;
		}

		private void WriteMapAndGameDatas()
		{
			Console.WriteLine();
			int mapWritingWidth = 7;

			for (int row = _player.Position.YPosition - mapWritingWidth; row <= _player.Position.YPosition + mapWritingWidth; row++)
			{
				for (int column = _player.Position.XPosition - mapWritingWidth; column <= _player.Position.XPosition + mapWritingWidth; column++)
				{
					if (row == _player.Position.YPosition && column == _player.Position.XPosition)
					{
						Console.Write("X  ");
					}
					else
					{
						Console.Write(_map[row, column].ShortType + " ");
					}
				}
				Console.WriteLine();
			}

			Console.WriteLine();
			Console.WriteLine("You are this field: " + _map[_player.Position.YPosition, _player.Position.XPosition].Type
				+ " (coordinates: " + _player.Position.XPosition + ", " + _player.Position.YPosition + ")");

			Console.WriteLine();
			Console.WriteLine("Part of the day: " + (_player.Daytime ? "daytime" : "night"));
			Console.WriteLine("Remaining action points in this daytime: " + _player.ActionPoints);

			Console.WriteLine();
			Console.WriteLine("Hp: " + _player.Hp + ", Brain: " + _player.Brain + ", Hunger: " + _player.Hunger + ", Thirst: " + _player.Thirst);

			Console.WriteLine();
			Console.WriteLine("Equipments: ");
			Console.WriteLine(Constants.Axe + ": " + (_player.Tools[Constants.Axe] != null ? _player.Tools[Constants.Axe].Live + " tree(s)" : "-"));
			Console.WriteLine(Constants.Pickaxe + ": " + (_player.Tools[Constants.Pickaxe] != null ? _player.Tools[Constants.Pickaxe].Live + " stone(s)" : "-"));
			Console.WriteLine(Constants.FlowerWreath + ": " + (_player.FlowerWreath != null ? _player.FlowerWreath.Live + " day(s)" : "-"));

			Console.Write(Constants.Campfire + "(s): ");
			List<Campfire> campfires = _player.Campfires;
			if (campfires.Count == 0)
			{
				Console.WriteLine(" -");
			}
			else
			{
				for (int i = 0; i <= campfires.Count - 2; i++)
				{
					Console.Write("(" + campfires[i].Position.XPosition + ", " + campfires[i].Position.YPosition + "): " + campfires[i].Live + " day(s), ");
				}
				int lastIndex = campfires.Count - 1;
				Console.WriteLine("(" + campfires[lastIndex].Position.XPosition + ", " + campfires[lastIndex].Position.YPosition + "): " + campfires[lastIndex].Live + " day(s)");
			}

			Console.WriteLine();
			Console.WriteLine("Your resources: ");
			Dictionary<string, int> playerResources = _player.Resources;
			foreach (string key in playerResources.Keys)
			{
				Console.WriteLine(key + ": " + playerResources[key]);
			}
		}

		private bool ConfirmQuit()
		{
			while(true)
			{
				Console.WriteLine();
				Console.WriteLine("Are you sure you want to quit? (y/n)");
				string input = Console.ReadLine();

				switch (input.ToLower())
				{
					case "y":
						return true;
					case "n":
						return false;
					default:
						Console.WriteLine();
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}

		private void MakeEquipment()
		{
			Console.WriteLine();
			Console.WriteLine("Please, choose an equipment!");

			while (true)
			{
				var equipment = Console.ReadKey(true).Key;

				switch(equipment)
				{
					case ConsoleKey.A:
						_player = Axe.Create(_player);
						break;
					case ConsoleKey.P:
						_player = Pickaxe.Create(_player);
						break;
					case ConsoleKey.F:
						_player = FlowerWreath.Create(_player);
						break;
					case ConsoleKey.C:
						_player = Campfire.Create(_player);
						break;
					default:
						Console.WriteLine();
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}

		private void Play()
		{
			bool playerWantToQuit = false;

			while (!playerWantToQuit)
			{
				WriteMapAndGameDatas();

				Console.WriteLine();
				Console.WriteLine("Choose an action!");
				var action = Console.ReadKey(true).Key;

				try
				{
					switch (action)
					{
						case ConsoleKey.LeftArrow:
							_player.Move(Constants.Left, _map);
							break;
						case ConsoleKey.RightArrow:
							_player.Move(Constants.Right, _map);
							break;
						case ConsoleKey.UpArrow:
							_player.Move(Constants.Up, _map);
							break;
						case ConsoleKey.DownArrow:
							_player.Move(Constants.Down, _map);
							break;
						case ConsoleKey.C:
							_player = _map[_player.Position.YPosition, _player.Position.XPosition].Collect(_player);
							break;
						case ConsoleKey.W:
							_player.Wait();
							break;
						case ConsoleKey.M:
							MakeEquipment();
							break;
						case ConsoleKey.Q:
							playerWantToQuit = ConfirmQuit();
							break;
						default:
							Console.WriteLine();
							Console.WriteLine(Constants.WrongInputMessage);
							break;
					}
				}
				catch (WrongActionException exception)
				{
					Console.WriteLine("You would like to make an incorrect action! " + exception.Message);
				}
				catch (YouAreDeadException exception)
				{
					Console.WriteLine(exception.Message);
					playerWantToQuit = true;
				}
				catch (Exception exception)
				{
					Console.WriteLine("Unknown error! " + exception.Message);
				} 
			}
		}
	}
}
