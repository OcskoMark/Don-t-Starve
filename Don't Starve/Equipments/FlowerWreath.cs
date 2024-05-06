using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Equipments
{
	class FlowerWreath : Equipment
	{
		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Flower] = Game.MultipliedByDifficultyModifier(10)
		};

		public FlowerWreath() : base(Game.DividedByDifficultyModifier(15), "Flower wreath") { }

		public new static Dictionary<string, int> RawMaterials { get => _rawMaterials; }
	}
}
