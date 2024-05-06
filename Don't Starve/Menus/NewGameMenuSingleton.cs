using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Menus
{
	class NewGameMenuSingleton
	{
		private static NewGameMenuSingleton _instance = null;
		private const string _backMainMenuCommand = "b";
		private const string _backMainMenuText = _backMainMenuCommand + " - Back to the main menu";

		private NewGameMenuSingleton() { }

		public static NewGameMenuSingleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new NewGameMenuSingleton();
			}

			return _instance;
		}

		private int ChooseMapSize()
		{
			const string smallOption = "1";
			const string mediumOption = "2";
			const string largeOption = "3";
			const string hugeOption = "4";

			const int smallSize = 150;
			const int mediumSize = 300;
			const int largeSize = 450;
			const int hugeSize = 600;

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please, select map size!");
				Console.WriteLine(smallOption + " - Small (" + smallSize + " x " + smallSize + ")");
				Console.WriteLine(mediumOption + " - Average (" + mediumSize + " x " + mediumSize + ")");
				Console.WriteLine(largeOption + " - Large (" + largeSize + " x " + largeSize + ")");
				Console.WriteLine(hugeOption + " - Huge (" + hugeSize + " x " + hugeSize + ")");
				Console.WriteLine(_backMainMenuText);

				string input = Console.ReadLine();

				switch (input)
				{
					case smallOption:
						return smallSize;
					case mediumOption:
						return mediumSize;
					case largeOption:
						return largeSize;
					case hugeOption:
						return hugeSize;
					case _backMainMenuCommand:
						MainMenuSingleton.GetInstance().ChooseMainMenuOptions();
						break;
					default:
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}

		private double ChooseDifficulty()
		{
			const string easyOption = "1";
			const string normalOption = "2";
			const string hardOption = "3";

			const double easyDificultyModifier = 0.75;
			const double normalDifficultyModifier = 1.0;
			const double hardDifficultyModifier = 1.25;

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please, choose a difficulty!");
				Console.WriteLine(easyOption + " - Easy");
				Console.WriteLine(normalOption + " - Normal");
				Console.WriteLine(hardOption + " - Hard");
				Console.WriteLine(_backMainMenuText);

				string input = Console.ReadLine();

				switch (input)
				{
					case easyOption:
						return easyDificultyModifier;
					case normalOption:
						return normalDifficultyModifier;
					case hardOption:
						return hardDifficultyModifier;
					case _backMainMenuCommand:
						MainMenuSingleton.GetInstance().ChooseMainMenuOptions();
						break;
					default:
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}

		public void ChooseNewGameOptions()
		{
			int mapSize = ChooseMapSize();
			double difficultyModifier = ChooseDifficulty();

			Console.WriteLine();
			Console.WriteLine("Please, type your name!");
			string playerName = Console.ReadLine();
			Game game = new Game(mapSize, difficultyModifier, playerName);
		}
	}
}
