using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic.GameBoard
{
   public class Point
    {
        
        public PointLocation Location { get; private set; }

        public PointStatus Status { get;  set; }

        public Point(int x, int y ,PointStatus status = PointStatus.Empty)
        {
            Location = new PointLocation(x, y); Status = status; 
        }

        public enum PointStatus
        {
            Empty = 0, Food = 1, Snake = 2 , Barier = 3
        }

       
    }

    public class PointLocation
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public PointLocation(int x,int y)
        {
            X = x;  Y = y; 
        }
    }




}
