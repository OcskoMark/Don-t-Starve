using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Menus
{
	class MainMenuSingleton
	{
		private bool _isStart;
		private static MainMenuSingleton _instance = null;

		private MainMenuSingleton()
		{
			_isStart = true;
		}

		public static MainMenuSingleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new MainMenuSingleton();
			}

			return _instance;
		}

		private void Quit()
		{

			bool validInput = false;

			while (!validInput)
			{
				Console.WriteLine();
				Console.WriteLine("Are you sure you quit? (y/n)");

				string input = Console.ReadLine();

				switch (input)
				{
					case "y":
						validInput = true;
						Console.WriteLine();
						Console.WriteLine("Goodbye!");
						Console.WriteLine("(Press any key to exit...)");
						Console.ReadKey();
						Environment.Exit(0);
						break;

					case "n":
						validInput = true;
						ChooseMainMenuOptions();
						break;

					default:
						Console.WriteLine();
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}

		public void ChooseMainMenuOptions()
		{
			const string newGameCommand = "1";
			const string quitCommand = "2";

			if (_isStart)
			{
				Console.WriteLine("Welcome in the Don't Starve game!");
				_isStart = false;
			}

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please choose an option!");
				Console.WriteLine(newGameCommand + " - New Game");
				Console.WriteLine(quitCommand + " - Exit the program");

				String input = Console.ReadLine();

				switch (input)
				{
					case newGameCommand:
						NewGameMenuSingleton newGame = NewGameMenuSingleton.GetInstance();
						newGame.ChooseNewGameOptions();
						break;
					case quitCommand:
						Quit();
						break;
					default:
						Console.WriteLine(Constants.WrongInputMessage);
						break;
				}
			}
		}
	}
}
