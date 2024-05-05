using Don_t_Starve.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMenuSingleton mainMenu = MainMenuSingleton.GetInstance();
			mainMenu.ChooseMainMenuOptions();
			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
