using Don_t_Starve.Entities;
using Don_t_Starve.Exceptions;
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
			if (player.Tools[Constants.Axe] != null && player.Tools[Constants.Axe].IsUsable())
			{
				return Amount > 0 ? true : false;
			}
			else
			{
				throw new WrongActionException("You have not the necessary equipment to collect this resource! (" + Constants.Axe + ")");
			}
		}

		protected override Player CollectResource(Player player)
		{
			player.CollectResource(Type, 3, Constants.Axe);
			Amount--;
			return player;
		}
	}
}
