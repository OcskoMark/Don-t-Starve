using System;
using Don_t_Starve.GameEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Equipments
{
	class Pickaxe : Equipment
	{
		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Tree] = GameCoefficients.MultipliedByDifficultyModifier(2),
			[Constants.Grass] = GameCoefficients.MultipliedByDifficultyModifier(2)
		};

		public Pickaxe() : base(GameCoefficients.DividedByDifficultyModifier(7), Constants.Pickaxe) { }

		public static Dictionary<string, int> RawMaterials { get => _rawMaterials; }

		public static void Create(Player player)
		{
			player.CreateEquipment(_rawMaterials, 1, Constants.Pickaxe);
		}
	}
}
