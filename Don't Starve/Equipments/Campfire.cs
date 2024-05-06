using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Equipments
{
	class Campfire : Equipment
	{
		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Tree] = Game.MultipliedByDifficultyModifier(2),
			[Constants.Stone] = Game.MultipliedByDifficultyModifier(4),
			[Constants.Grass] = Game.MultipliedByDifficultyModifier(2)
		};

		public Campfire() : base(Game.DividedByDifficultyModifier(1), "Campfire") { }

		public new static Dictionary<string, int> RawMaterials { get => _rawMaterials; }
	}
}
