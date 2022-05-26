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
            drawler = new Drawler(GameGrid,BoardBorder);
            Game.CreateLevel();
            Game.CreateSnake();
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
            if (Game.WaitingDirectory != Logic.Snake.Directory.Null)
            {
                Game.PrepareMove();
                drawler.DrawBoard();
                if (Game.GameCrash != Game.CrashType.AllIsGod)
                {
                    MessageBox.Show(Game.GameCrash.ToString());
                    GameTimer.Stop();
                }
                else
                {
                    Game.GameMove();
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Game.ChangeNextDirectory(Logic.Snake.Directory.Up);
                    break;
                case Key.Down:
                    Game.ChangeNextDirectory(Logic.Snake.Directory.Down);
                    break;
                case Key.Left:
                    Game.ChangeNextDirectory(Logic.Snake.Directory.Left);
                    break;
                case Key.Right:
                    Game.ChangeNextDirectory(Logic.Snake.Directory.Right);
                    break;


            }
        }
    }
}
