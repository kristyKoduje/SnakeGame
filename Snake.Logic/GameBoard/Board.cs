using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic.GameBoard
{
    public class Board
    {
        public BoardSize Size { get; private set; }


        public Point[,] Points { get; private set; }

        public List<Point> ListPoints { get; private set; }

        public Board(Point[,] points)
        {
            Size = new BoardSize(points.GetLength(0) - 1, points.GetLength(1) - 1);
            Points = points;
            ListPoints = new List<Point>();

            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    ListPoints.Add(points[i, j]);
                }
            }
        }
    }


    public class BoardSize
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public BoardSize(int x,int y)
        {
            X = x; Y = y; 
        }

    }




}
