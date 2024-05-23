using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class GameCoefficients
	{

		private static double _difficultyModifier;
		private double _hpLossAtNightWithoutCampfire;
		private double _brainLossNightWithoutCampfire;
		private double _brainLossNight;
		private double _hungerLossByAction;
		private double _thirstLossByActionAtNight;
		private double _thirstLossByActionAtDaytime;
		private double _brainGainWithFlowerWreath;
		private double _brainGainCollectingFlower;

		private double _maxSafetyDistanceFromCampfire;

		public GameCoefficients(double difficultyModifier)
		{
			_difficultyModifier = difficultyModifier;
			_hpLossAtNightWithoutCampfire = MultipliedByDifficultyModifier(5.0);
			_brainLossNightWithoutCampfire = MultipliedByDifficultyModifier(7.0);
			_brainLossNight = MultipliedByDifficultyModifier(0.4);
			_hungerLossByAction = MultipliedByDifficultyModifier(0.4);
			_thirstLossByActionAtNight = MultipliedByDifficultyModifier(0.15);
			_thirstLossByActionAtDaytime = MultipliedByDifficultyModifier(0.3);
			_brainGainWithFlowerWreath = DividedByDifficultyModifier(0.075);
			_brainGainCollectingFlower = DividedByDifficultyModifier(2.0);

			_maxSafetyDistanceFromCampfire = DividedByDifficultyModifier(3.0);
		}

		public double DifficultyModifier { get => _difficultyModifier; }
		public double HpLossAtNightWithoutCampfire { get => _hpLossAtNightWithoutCampfire; }
		public double BrainLossNightWithoutCampfire { get => _brainLossNightWithoutCampfire; }
		public double BrainLossNight { get => _brainLossNight; }
		public double HungerLossByAction { get => _hungerLossByAction; }
		public double ThirstLossByActionAtNight { get => _thirstLossByActionAtNight; }
		public double ThirstLossByActionAtDaytime { get => _thirstLossByActionAtDaytime; }
		public double BrainGainWithFlowerWreath { get => _brainGainWithFlowerWreath; }
		public double MaxSafetyDistanceFromCampfire { get => _maxSafetyDistanceFromCampfire; }
		public double BrainGainCollectingFlower { get => _brainGainCollectingFlower; }

		private static int GetNotNull(double value)
		{
			int roundedResult = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
			return roundedResult == 0 ? 1 : roundedResult;
		}

		public static double DividedByDifficultyModifier(double value)
		{
			return value / _difficultyModifier;
		}

		public double MultipliedByDifficultyModifier(double value)
		{
			return value * _difficultyModifier;
		}

		public static int DividedByDifficultyModifier(int value)
		{
			return GetNotNull(value / _difficultyModifier);
		}

		public static int MultipliedByDifficultyModifier(int value)
		{
			return GetNotNull(value * _difficultyModifier);
		}
	}
}
