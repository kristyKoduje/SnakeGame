using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public static class Game
    {
        public static GameLevel Level;


        public static void SnakeMove()
        {
            //ToDo : hlavni logika chybi ...
            //Toto bude posouvat hada a resit kolize (ay ho dodelam).
            
        }


        //ToDo : Tohle asi budeme nacitat z venku, ale zatim netusim jak ....
        // Vygeneruje prvni level
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

                    points[i, j] = point;
                    index++;
                }
            }

            GameBoard.Board board = new GameBoard.Board(points);

            Level = new GameLevel (1,board, true, 500, 20);



        }
    }
}
