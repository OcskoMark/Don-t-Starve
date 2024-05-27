using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Entities;
using Don_t_Starve.Exceptions;

namespace Don_t_Starve.Map
{
	class Land : Field
	{
		private int _amount;

		public Land() : base(Constants.Land)
		{
			_amount = 0;
		}

		public Land(string type, int amount) : base(type)
		{
			Amount = amount;
		}

		public int Amount
		{
			get => _amount;

			set
			{
				if (Type == Constants.Land)
				{
					_amount = 0;
				}
				else
				{
					if (value < 0)
					{
						throw new Exception("A resource amount can not be negative!");
					}
					else
					{
						_amount = value;
					}

					if (_amount == 0)
					{
						UpdateType(Constants.Land);
					}
				}
			}
				
		}

		public override bool isWalkable()
		{
			return true;
		}

		protected override bool IsCollectible(Player player)
		{
			return Amount > 0 ? true : false;
		}

		protected virtual Player CollectResource(Player player)
		{
			player.CollectResource(Type, 1);
			return player;
		}

		public override Player Collect(Player player)
		{
			if (IsCollectible(player))
			{
				Amount--;
				return CollectResource(player);
			}
			else
			{
				throw new WrongActionException("This field has not any collectible resources!");
			}
		}
	}
}
