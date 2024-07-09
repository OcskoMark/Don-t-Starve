using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.Map
{
	class Position
	{
		private int _xPosition;
		private int _yPosition;

		public Position(int xPosition, int yPosition)
		{
			_xPosition = xPosition;
			_yPosition = yPosition;
		}

		public int XPosition { get => _xPosition; set => _xPosition = value; }
		public int YPosition { get => _yPosition; set => _yPosition = value; }

		public double GetDistance(Position position)
		{
			return Math.Sqrt(Math.Pow((_xPosition - position.XPosition), 2) + Math.Pow((_yPosition - position.YPosition), 2));
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Position))
			{
				return false;
			}
			else
			{
				return (XPosition == ((Position)obj).XPosition && YPosition == ((Position)obj).YPosition);
			}
		}
	}
}
