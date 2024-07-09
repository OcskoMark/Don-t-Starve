using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class PlayerGameCoefficients
	{
		public readonly double HpLossAtNightWithoutCampfire = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(5.0);
		public readonly double BrainLossNightWithoutCampfire = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(7.0);
		public readonly double BrainLossNight = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.4);
		public readonly double HungerLossByAction = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.4);
		public readonly double ThirstLossByActionAtNight = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.15);
		public readonly double ThirstLossByActionAtDaytime = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(0.3);
		public readonly double BrainGainWithFlowerWreath = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(0.075);
		public readonly double BrainGainCollectingFlower = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);

		public readonly double MaxSafetyDistanceFromCampfire = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.0);

		public readonly double GainThirstDrinkingUnboiledWater = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(4.0);
		public readonly double GainHungerDrinkingUnboiledWater = 0.0;
		public readonly double GainHpDrinkingUnboiledWater = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(-1.0);
		public readonly double GainBrainDrinkingUnboiledWater = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);

		public readonly double GainThirstDrinkingBoiledWater = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.5);
		public readonly double GainHungerDrinkingBoiledWater = 0.0;
		public readonly double GainHpDrinkingBoiledWater = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(4.0);
		public readonly double GainBrainDrinkingBoiledWater = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.0);

		public readonly double GainThirstEatingUnbakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);
		public readonly double GainHungerEatingUnbakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1.0);
		public readonly double GainHpEatingUnbakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.0);
		public readonly double GainBrainEatingUnbakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1.5);

		public readonly double GainThirstEatingBakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1.0);
		public readonly double GainHungerEatingBakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);
		public readonly double GainHpEatingBakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(8.0);
		public readonly double GainBrainEatingBakedHerb = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.5);

		public readonly double GainThirstEatingUnbakedCarrot = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(-0.5);
		public readonly double GainHungerEatingUnbakedCarrot = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(10.0);
		public readonly double GainHpEatingUnbakedCarrot = 0.0;
		public readonly double GainBrainEatingUnbakedCarrot = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1.0);

		public readonly double GainThirstEatingBakedCarrot = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(-1.0);
		public readonly double GainHungerEatingBakedCarrot = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(8.0);
		public readonly double GainHpEatingBakedCarrot = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);
		public readonly double GainBrainEatingBakedCarrot = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(3.0);

		public readonly double GainThirstEatingUnbakedBerry = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(0.75);
		public readonly double GainHungerEatingUnbakedBerry = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(10.0);
		public readonly double GainHpEatingUnbakedBerry = GameCoefficientsCalculatorSingleton.MultipliedByDifficultyModifier(-5.0);
		public readonly double GainBrainEatingUnbakedBerry = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(1.0);

		public readonly double GainThirstEatingBakedBerry = 0.0;
		public readonly double GainHungerEatingBakedBerry = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(8.0);
		public readonly double GainHpEatingBakedBerry = 0.0;
		public readonly double GainBrainEatingBakedBerry = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(2.0);

		public PlayerGameCoefficients()
		{
			
		}
	}
}
