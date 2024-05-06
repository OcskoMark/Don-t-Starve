using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Equipments
{
	class Axe : Equipment
	{

		private static Dictionary<string, int> _rawMaterials = new Dictionary<string, int>()
		{
			[Constants.Grass] = Game.MultipliedByDifficultyModifier(2),
			[Constants.Bough] = Game.MultipliedByDifficultyModifier(3)
		};

		public Axe() : base(Game.DividedByDifficultyModifier(10), "Axe") { }

		public new static Dictionary<string, int> RawMaterials { get => _rawMaterials; }
	}
}
