using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			} else
			{
				throw new InvalidOperationException("This " + _name + " tool is not usable anymore!");
			}
		}

		public static Dictionary<string, int> RawMaterials
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
