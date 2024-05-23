using System;
using Don_t_Starve.GameEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Starve.Exceptions;
using Don_t_Starve.Entities;

namespace Don_t_Starve.Equipments
{
	abstract class Equipment
	{
		private int _live;
		private string _name;

		public Equipment(int live, string name)
		{
			_live = live;
			_name = name;
		}
		public int Live { get => _live; }
		public string Name { get => _name; }

		public bool IsUsable()
		{
			return _live > 0 ? true : false;
		}

		public void Use()
		{
			if (IsUsable())
			{
				_live--;
			}
			else
			{
				throw new WrongActionException("This " + _name + " is not usable anymore!");
			}
		}
	}
}
