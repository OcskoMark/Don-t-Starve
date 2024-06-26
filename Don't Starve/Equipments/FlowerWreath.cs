﻿using System;
using Don_t_Starve.GameEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Equipments
{
	class FlowerWreath : Equipment
	{
		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Flower] = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(10)
		};

		public FlowerWreath() : base(GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(15), Constants.FlowerWreath) { }

		public static Dictionary<string, int> RawMaterials { get => _rawMaterials; }

		public static Player Create(Player player)
		{
			player.CreateEquipment(_rawMaterials, 1, Constants.FlowerWreath);
			return player;
		}
	}
}
