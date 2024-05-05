using Don_t_Starve.Entities;
using Don_t_Starve.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve
{
	class Game
	{
		private int _mapSize;
		private static double _difficultyModifier;
		private Player _player;

		public Game(int mapSize, double difficultyModifier, string playerName)
		{
			_mapSize = mapSize;
			_difficultyModifier = difficultyModifier;
			_player = new Player(playerName);
		}

		public static double DividedByDifficultyModifier(double value)
		{
			return value / _difficultyModifier;
		}

		public static double MultipliedByDifficultyModifier(double value)
		{
			return value * _difficultyModifier;
		}

		public static int DividedByDifficultyModifier(int value)
		{
			return Convert.ToInt32(Math.Round(value / _difficultyModifier));
		}

		public static int MultipliedByDifficultyModifier(int value)
		{
			return Convert.ToInt32(Math.Round(value * _difficultyModifier));
		}
	}
}
