using Don_t_Starve.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Entities
{
	class Player
	{
		private Dictionary<string, int> inventory = new Dictionary<string, int>();
		private double _hp;
		private double _brain;
		private double _hunger;
		private int _actionPoints;
		private bool _dayTime;
		private string _name;

		public Player(string name)
		{
			_name = name;
			_hp = 100.0;
			_brain = 100.0;
			_hunger = 100.0;
			foreach (string collectible in Constants.collectibles)
			{
				inventory[collectible] = 0;
			}
			_actionPoints = 75;
			_dayTime = true;
		}
	}
}
