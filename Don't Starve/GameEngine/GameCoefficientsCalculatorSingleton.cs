using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class GameCoefficientsCalculatorSingleton
	{
		private static double _difficultyModifier;
		private static GameCoefficientsCalculatorSingleton _instance = null;

		private GameCoefficientsCalculatorSingleton(double difficultyModifier)
		{
			_difficultyModifier = difficultyModifier;
		}

		public static GameCoefficientsCalculatorSingleton GetInstance(double difficultyModifier)
		{
			if (_instance == null)
			{
				_instance = new GameCoefficientsCalculatorSingleton(difficultyModifier);
			}
			else
			{
				DifficultyModifier = difficultyModifier;
			}

			return _instance;
		}

		public static double DifficultyModifier { get => _difficultyModifier; set => _difficultyModifier = value; }

		private static int GetNotNull(double value)
		{
			int roundedResult = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
			return roundedResult == 0 ? 1 : roundedResult;
		}

		public static double DividedByDifficultyModifier(double value)
		{
			return value / DifficultyModifier;
		}

		public static double MultipliedByDifficultyModifier(double value)
		{
			return value * DifficultyModifier;
		}

		public static int DividedByDifficultyModifier(int value)
		{
			return GetNotNull(value / DifficultyModifier);
		}

		public static int MultipliedByDifficultyModifier(int value)
		{
			return GetNotNull(value * DifficultyModifier);
		}
	}
}
