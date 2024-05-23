using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve
{
	//This class contains the multiple used constants.
	static class Constants
	{
		// These are the constants for the field and collectible names.
		public const string Water = "water";
		public const string Land = "land";
		public const string Bough = "bough";
		public const string Tree = "tree";
		public const string Stone = "stone";
		public const string Grass = "grass";
		public const string Flower = "flower";
		public const string Herb = "herb";
		public const string Carrot = "carrot";
		public const string Berry = "berry";
		public const int MaxCollectibleSmallAmount = 5;
		public const int MaxCollectibleLargeAmount = 10;
		public static readonly List<string> collectibles = new List<string>
		{
			Water, Bough, Tree, Stone, Grass, Flower, Herb, Carrot, Berry
		};

		//These are the names of equipments.
		public const string Axe = "Axe";
		public const string Pickaxe = "Pickaxe";
		public const string Campfire = "Campfire";
		public const string FlowerWreath = "Flower wreath";

		//directions
		public const string Left = "left";
		public const string Right = "right";
		public const string Up = "up";
		public const string Down = "down";

		//These are the messages for user.
		public const string WrongInputMessage = "Wrong input!" + "\n" + "Please, type a valid input!" + "\n";
	}
}
