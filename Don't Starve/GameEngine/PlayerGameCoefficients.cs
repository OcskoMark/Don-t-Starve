using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class PlayerGameCoefficients
	{
		private double _hpLossAtNightWithoutCampfire;
		private double _brainLossNightWithoutCampfire;
		private double _brainLossNight;
		private double _hungerLossByAction;
		private double _thirstLossByActionAtNight;
		private double _thirstLossByActionAtDaytime;
		private double _brainGainWithFlowerWreath;
		private double _brainGainCollectingFlower;

		private double _maxSafetyDistanceFromCampfire;

		public PlayerGameCoefficients()
		{
			_hpLossAtNightWithoutCampfire = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(5.0);
			_brainLossNightWithoutCampfire = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(7.0);
			_brainLossNight = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.4);
			_hungerLossByAction = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.4);
			_thirstLossByActionAtNight = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.15);
			_thirstLossByActionAtDaytime = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.3);
			_brainGainWithFlowerWreath = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(0.075);
			_brainGainCollectingFlower = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);
			_maxSafetyDistanceFromCampfire = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.0);
		}

		public double HpLossAtNightWithoutCampfire { get => _hpLossAtNightWithoutCampfire; }
		public double BrainLossNightWithoutCampfire { get => _brainLossNightWithoutCampfire; }
		public double BrainLossNight { get => _brainLossNight; }
		public double HungerLossByAction { get => _hungerLossByAction; }
		public double ThirstLossByActionAtNight { get => _thirstLossByActionAtNight; }
		public double ThirstLossByActionAtDaytime { get => _thirstLossByActionAtDaytime; }
		public double BrainGainWithFlowerWreath { get => _brainGainWithFlowerWreath; }
		public double MaxSafetyDistanceFromCampfire { get => _maxSafetyDistanceFromCampfire; }
		public double BrainGainCollectingFlower { get => _brainGainCollectingFlower; }
	}
}
