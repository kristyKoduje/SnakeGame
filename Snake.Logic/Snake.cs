using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Logic.GameBoard;

namespace Snake.Logic
{
    public class Snake : Queue<Point>
    {

        public Point HeadPoint { get; private set; }

        public Directory ActualDirectory { get; set; }

     


        public Snake(Point[] snakePoints)
        {
            ActualDirectory = Directory.Null;
            
            for (int i = 0; i < snakePoints.Length; i++)
            {
                AddPoint(snakePoints[i]);
            }

        }

      

        public void MoveSnake(Point point)
        {
            if (point.Status != Point.PointStatus.Food)
            {
                TakePoint();
            }
            else
            {
                Game.FoodWasEaten();
            }

            AddPoint(point);

        }
        
        
        
        private void AddPoint (Point point)
        {
            Enqueue(point);
            HeadPoint = point;
            point.Status = Point.PointStatus.Snake;

        }


        private Point TakePoint()
        {
            Point point = this.Dequeue();
            point.Status = Point.PointStatus.Empty;
            return point;
        }
        

        public enum Directory
        { 

          Null = 0 , Right = 1 , Left = -1 , Up = 2 , Down = -2 

        }





    }
}
