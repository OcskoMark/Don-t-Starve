using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Exceptions
{
	class YouAreDeadException : Exception
	{
		public YouAreDeadException() : base("Game over! You are dead!") { }
	}
}
