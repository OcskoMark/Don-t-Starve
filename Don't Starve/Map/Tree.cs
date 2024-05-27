using Don_t_Starve.Entities;
using Don_t_Starve.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Map
{
	class Tree : Land
	{
		public Tree(int amount) 
			: base(Constants.Tree, amount) { }

		protected override bool IsCollectible(Player player)
		{
			return (Amount > 0 && player.Tools[Constants.Axe] != null && player.Tools[Constants.Axe].IsUsable()) ? true : false;
		}

		protected override Player CollectResource(Player player)
		{
			player.CollectResource(Type, 3, Constants.Axe);
			return player;
		}
	}
}
