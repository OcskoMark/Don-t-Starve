using Don_t_Starve.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Map
{
	class FieldFactory
	{
		private int _maxAmountOfSmallResource;
		private int _maxAmountOfLargeResource;
		private Random _random;

		public FieldFactory()
		{
			_maxAmountOfSmallResource = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(5);
			_maxAmountOfLargeResource = GameCoefficientsCalculatorSingleton.DividedByDifficultyModifier(10);
			_random = new Random();
		}

		public Field CreateField(string type)
		{
			switch(type)
			{
				case Constants.Water:
					return new Water();
				case Constants.Land:
					return new Land();
				case Constants.Berry:
					return new Land(Constants.Berry, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Bough:
					return new Land(Constants.Bough, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Carrot:
					return new Land(Constants.Carrot, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Flower:
					return new Land(Constants.Flower, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Grass:
					return new Land(Constants.Grass, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Herb:
					return new Land(Constants.Herb, _random.Next(1, _maxAmountOfSmallResource));
				case Constants.Stone:
					return new Stone(_random.Next(1, _maxAmountOfLargeResource));
				case Constants.Tree:
					return new Tree(_random.Next(1, _maxAmountOfLargeResource));
				default:
					throw new Exception("Unknown field type!");
			}
		}
	}
}
