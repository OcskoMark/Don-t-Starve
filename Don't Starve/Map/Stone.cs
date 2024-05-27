using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;
using Don_t_Starve.GameEngine;

namespace Don_t_Starve.Map
{
	class Stone : Land
	{
		public Stone(int amount)
			: base(Constants.Stone, amount) { }

		protected override bool IsCollectible(Player player)
		{
			return (Amount > 0 && player.Tools[Constants.Pickaxe] != null && player.Tools[Constants.Pickaxe].IsUsable()) ? true : false;
		}

		protected override Player CollectResource(Player player)
		{
			player.CollectResource(Type, 4, Constants.Pickaxe);
			return player;
		}
	}
}
