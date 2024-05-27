using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Map
{
	class Water : Field
	{

		public Water() : base(Constants.Water) { }

		public override bool isWalkable()
		{
			return false;
		}

		protected override bool IsCollectible(Player player)
		{
			return true;
		}

		public override Player Collect(Player player)
		{
			player.CollectResource(base.Type, 1);
			return player;
		}
	}
}
