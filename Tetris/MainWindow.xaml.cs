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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageSource[] cellImages = new ImageSource[]
        {
            new BitmapImage(new Uri("TetrisAssets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileRed.png", UriKind.Relative))
        };

        private readonly ImageSource[] brickImages = new ImageSource[]
        {
            new BitmapImage(new Uri("TetrisAssets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-Z.png", UriKind.Relative))
        };

        private Image[,] imageControls;
        private GameController gameController = new GameController();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameController.Grid);
        }

        private Image[,] SetupGameCanvas(Playfield grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };
                    Canvas.SetTop(imageControl, (row - 2) * cellSize);
                    Canvas.SetLeft(imageControl, column * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[row, column] = imageControl;
                }
            }

            return imageControls;
        }

        private void DrawGrid(Playfield grid)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    int cellType = grid[row, column];
                    imageControls[row, column].Source = cellImages[cellType];
                }
            }
        }

        private void DrawBrick(Tetrominoe brick)
        {
            foreach (Cell cell in brick.CellPositionsOnGrid())
            {
                
                imageControls[cell.Row, cell.Column].Source = cellImages[(int)brick.Type];
            }
        }

        private void Draw(GameController gameController)
        {
            DrawGrid(gameController.Grid);
            DrawBrick(gameController.CurrentBrick);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameController.GameOver)
            {
                return;
            }

            if(e.Key == Key.Left)
            {
                gameController.MoveBrickLeft();
            } else if (e.Key == Key.Right)
            {
                gameController.MoveBrickRight();
            }else if (e.Key == Key.Down)
            {
                gameController.MoveBrickDown();
            }else if (e.Key == Key.Up)
            {
                gameController.RotateBrickCW();
            }else if(e.Key == Key.Z)
            {
                gameController.RotateBrickAntiCW();
            }
            else
            {
                return;
            }

            Draw(gameController);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }


        private async Task GameLoop()
        {
            Draw(gameController);

            while (!gameController.GameOver)
            {
                await Task.Delay(500);
                gameController.MoveBrickDown();
                Draw(gameController);
            }

            GameOverMenu.Visibility = Visibility.Visible;
        }
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
