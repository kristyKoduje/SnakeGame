using Snake.Logic.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class GameLevel
    {
        public int Level { get; private set; }

        public Board Board { get; private set; }

        public bool ThroughWall { get; private set; }
        
        public int SnakeSpeed { get; private set; }

        public int EndScore { get; private set; }


        
        public GameLevel (int level,Board board,bool throughWall, int snakeSpeed, int endScore)
        {
            Level = level; Board = board;ThroughWall = throughWall; SnakeSpeed = snakeSpeed; EndScore = endScore; 
        }





    }
}
