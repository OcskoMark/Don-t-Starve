using Don_t_Starve.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Map
{
	abstract class Field
	{
		private string _type;
		private string _shortType;

		protected Field(string type)
		{
			UpdateType(type);
		}

		public string Type { get => _type; }
		public string ShortType { get => _shortType; }

		protected void UpdateType(string type)
		{
			_type = type;
			_shortType = _type.Substring(0, 2);
		}

		public abstract bool isWalkable();

		protected abstract bool IsCollectible(Player player);

		public abstract Player Collect(Player player);
	}
}
