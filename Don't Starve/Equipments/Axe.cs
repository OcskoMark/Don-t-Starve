using System;
using Don_t_Starve.GameEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Equipments
{
	class Axe : Equipment
	{

		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Grass] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(2),
			[Constants.Bough] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(3)
		};

		public Axe() : base(GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(10), Constants.Axe) { }

		public static Dictionary<string, int> RawMaterials { get => _rawMaterials; }

		public static Player Create(Player player)
		{
			player.CreateEquipment(_rawMaterials, 1, Constants.Axe);
			return player;
		}
	}
}
