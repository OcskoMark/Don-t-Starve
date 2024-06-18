using Don_t_Starve.Map;
using Don_t_Starve.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Equipments
{
	class Campfire : Equipment
	{
		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Tree] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(2),
			[Constants.Stone] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(4),
			[Constants.Grass] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(2)
		};
		private Position _position;

		public Campfire(Position pos) : base(GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1), Constants.Campfire)
		{
			_position = pos;
		}

		public static Dictionary<string, int> RawMaterials { get => _rawMaterials; }
		public Position Position { get => _position; }

		public static Player Create(Player player)
		{
			player.CreateEquipment(_rawMaterials, 2, Constants.Campfire);
			return player;
		}
	}
}
