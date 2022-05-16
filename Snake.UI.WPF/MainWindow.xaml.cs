using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Snake.Logic;


namespace Snake.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Drawler drawler;

        DispatcherTimer GameTimer;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGameStart_Click(object sender, RoutedEventArgs e)
        {
            drawler = new Drawler(GameGrid);
            Game.CreateLevel();
            drawler.DrawStartGrid();
            drawler.DrawBoard();

            GameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(Game.Level.SnakeSpeed)
            };
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Game.SnakeMove();
            drawler.DrawBoard();    
        }
    }
}
