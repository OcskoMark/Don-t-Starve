using Don_t_Starve.Entities;
using Don_t_Starve.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Starve.GameEngine
{
	class Game
	{
		private int _mapSize;
		private int _oceanMinWidth;
		private double _difficultyModifier;
		private Player _player;

		public Game(int mapSize, double difficultyModifier, string playerName)
		{
			_mapSize = mapSize;
			_oceanMinWidth = 15;
			_difficultyModifier = difficultyModifier;
			_player = new Player(playerName, _oceanMinWidth, (_mapSize - _oceanMinWidth), new GameCoefficients(_difficultyModifier));
		}
	}
}
