using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public static class Game
    {
        public static GameLevel Level { get; private set; }
        public static Score Score { get; private set; }

        public static Snake Snake { get; private set; }

        public static Snake.Directory WaitingDirectory { get; private set; }

        public static GameBoard.PointLocation newPoint { get; private set; }

        public static CrashType  GameCrash = CrashType.AllIsGod;

        private static Random random { get; set; }

        

        public static void PrepareMove()
        {
                
            newPoint = GetNewPointLocation();

                GameCrash = GetCrash(newPoint);

                if (GameCrash == CrashType.WallCrash && Level.ThroughWall == true)
                {
                    newPoint = LocationAfterConflict(newPoint);
                    GameCrash = GetCrash(newPoint);
                }
        }

        
        
        
        public static void GameMove()
        {

            Snake.MoveSnake(Level.Board.Points[newPoint.X, newPoint.Y]);
            Snake.ActualDirectory = WaitingDirectory;
        }




        public static void ChangeNextDirectory(Snake.Directory directory)
        {
            if (((int)directory + (int)Snake.ActualDirectory) != 0)
            {
                WaitingDirectory = directory;

            }
            else
            {
                WaitingDirectory = Snake.ActualDirectory;
            }
        }


        
        private static GameBoard.PointLocation GetNewPointLocation()
        {
            switch (WaitingDirectory)
            {
                case Snake.Directory.Up:
                    return new GameBoard.PointLocation(Snake.HeadPoint.Location.X, Snake.HeadPoint.Location.Y - 1);
                case Snake.Directory.Down:
                    return new GameBoard.PointLocation(Snake.HeadPoint.Location.X, Snake.HeadPoint.Location.Y + 1);
                case Snake.Directory.Right:
                    return new GameBoard.PointLocation(Snake.HeadPoint.Location.X + 1,Snake.HeadPoint.Location.Y);
                case Snake.Directory.Left:
                    return new GameBoard.PointLocation(Snake.HeadPoint.Location.X - 1, Snake.HeadPoint.Location.Y);
                default:
                    return new GameBoard.PointLocation(Snake.HeadPoint.Location.X,Snake.HeadPoint.Location.Y);
            }

        }






        private static CrashType GetCrash(GameBoard.PointLocation pointLocation)
        {
            if (pointLocation.X > Level.Board.Points.GetLength(0) - 1 || pointLocation.X < 0 || pointLocation.Y > Level.Board.Points.GetLength(1) - 1 || pointLocation.Y < 0)
            {
                return CrashType.WallCrash;
            }

            
            var head = Snake.HeadPoint.Location;

            if (Level.Board.Points[pointLocation.X, pointLocation.Y].Status == GameBoard.Point.PointStatus.Snake && (Snake.HeadPoint.Location.Y != pointLocation.Y) && (Snake.HeadPoint.Location.X != pointLocation.X))
            {
                return CrashType.SnakeCrash;
            }

            if (Level.Board.Points[pointLocation.X, pointLocation.Y].Status == GameBoard.Point.PointStatus.Barier)
            {
                return CrashType.BarierCrash;
            }

            return CrashType.AllIsGod;

        }





        private static GameBoard.PointLocation LocationAfterConflict(GameBoard.PointLocation pointLocation)
        {


            if (pointLocation.X > Level.Board.Points.GetLength(0) - 1)
            {
                return new GameBoard.PointLocation(0, pointLocation.Y);
            }

            if (pointLocation.X < 0)
            {
                return new GameBoard.PointLocation(Level.Board.Points.GetLength(0) - 1, pointLocation.Y);
            }

            if (pointLocation.Y > Level.Board.Points.GetLength(1) - 1)
            {
                return new GameBoard.PointLocation(pointLocation.X, 0);
            }

            return new GameBoard.PointLocation(pointLocation.X, Level.Board.Points.GetLength(1) - 1);
        }


        public enum CrashType
        {
            WallCrash, BarierCrash, SnakeCrash, AllIsGod

        }







        public static void CreateSnake()
        {

            // zajistuje generovani hada v prostredku plochy
            // ToDo : Asi to neni nejlepsi reseni, mozna by melo byt soucasti levelu 
            Snake = new Snake(new[] { Level.Board.Points[(Level.Board.Points.GetLength(0) - 1) / 2, (Level.Board.Points.GetLength(1) - 1) / 2] , Level.Board.Points[(Level.Board.Points.GetLength(0) - 1) / 2 + 1, (Level.Board.Points.GetLength(1) - 1) / 2 ] });

        }


        // Vygeneruje prvni level
        //ToDo : Tohle asi budeme nacitat z venku, ale zatim netusim jak ....
        public static void CreateLevel()
        {
            int index = 0;

            GameBoard.Point[,] points = new GameBoard.Point[40, 40];

            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    GameBoard.Point point = new GameBoard.Point(i, j);

                    //Tohle vytvori nejake prekazky ....
                    if (index == 85 || index == 124 || index == 125 || index == 126 || index == 165 )
                    {
                        point.Status = GameBoard.Point.PointStatus.Barier;
                    }

                    //

                    if (index==99)
                    {
                        point.Status = GameBoard.Point.PointStatus.Food;
                    }
                    //

                    points[i, j] = point;
                    index++;
                }
            }

            GameBoard.Board board = new GameBoard.Board(points);

            Level = new GameLevel (1,board, true, 300, 20);
        }

        public static void FoodWasEaten()
        {
            Score.IncreaseFoodScore();
            random = new Random();
            Level.Board.Points[random.Next(0,39), random.Next(0,39) ].Status = GameBoard.Point.PointStatus.Food;
        }

        public static Score CreateScore()
        {
            Score = new Score();
            return Score;
        }






    }
}
