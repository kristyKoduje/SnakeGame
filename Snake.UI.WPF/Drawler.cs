﻿using Snake.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.UI.WPF
{
    internal class Drawler
    {
        private Grid GameGrid { get;  set; }

        private Border BoardBorder { get; set; }

        public Drawler(Grid gameGrid,Border boardBorder )
        {

            GameGrid = gameGrid; BoardBorder = boardBorder;

        }

        /// <summary>
        /// Uvodni vytvoreni slopcu a radku do gridu
        /// </summary>
        public void DrawStartGrid()
        {

            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < Game.Level.Board.Points.GetLength(1); i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < Game.Level.Board.Points.GetLength(0); i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }






            //GameGrid.RowDefinitions.Clear();
            //GameGrid.ColumnDefinitions.Clear();
            //for (int i = 0; i < Game.Level.Board.Points.GetLength(0); i++)
            //{
            //    GameGrid.RowDefinitions.Add(new RowDefinition());
            //}
            //for (int i = 0; i < Game.Level.Board.Points.GetLength(1); i++)
            //{
            //    GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
        }

        /// <summary>
        /// Vykresluje zajimave body pro plochu volat pri kazdem posunu.
        /// </summary>
        public void DrawBoard()
        {
            GameGrid.Children.Clear();

            var point = Game.Level.Board.ListPoints;

            var drawingPoints = point.Where(x => x.Status != Logic.GameBoard.Point.PointStatus.Empty).ToList();


            foreach (var item in drawingPoints)
            {
                Rectangle rec = new Rectangle();

                

                switch (item.Status)
                {
                    case Logic.GameBoard.Point.PointStatus.Barier:
                        rec.Fill = Brushes.DarkGray;
                        break;
                    case Logic.GameBoard.Point.PointStatus.Snake:
                        rec.Fill = Brushes.Red;
                        break;
                    case Logic.GameBoard.Point.PointStatus.Food:
                        rec.Fill = Brushes.Green;
                        break;
                    default:
                        rec.Fill = Brushes.White;
                        break;
                }

                Grid.SetRow(rec, item.Location.Y);
                Grid.SetColumn(rec, item.Location.X);
                GameGrid.Children.Add(rec);
            }

            
            // zelena = pruchozi stena --- vykresluje se pokazde, kdyby nas napadlo dat tam neco jako zmenu v pulce levelu :D 
            if (Game.Level.ThroughWall)
            {
               BoardBorder.BorderBrush = Brushes.Green;
            }
            else
            {
                BoardBorder.BorderBrush = Brushes.Red;
            }
           
        }


    }
        
}
