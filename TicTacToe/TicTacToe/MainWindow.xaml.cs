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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<int, Brush> _tileColors = new Dictionary<int, Brush>
        {
            { 0, Brushes.Gray },
            { 1, Brushes.Black },
            { 2, Brushes.White },
        };

        private Game _game;

        private Button[,] _tiles = new Button[0, 0];
        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            CreateGridElements();
            DrawGrid(_game.GameGrid);
            DataContext = _game;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int row = 0; row < _tiles.GetLength(0); row++)
            {
                for (int col = 0; col < _tiles.GetLength(1); col++)
                {
                    int id = grid[row, col];
                    Brush color = _tileColors[id];
                    _tiles[row, col].Background = color;
                }
            }
        }

        private void CreateGridElements()
        {
            for (var i = 0; i < _game.GameGrid.Rows; i++)
            {
                this.visualGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (var i = 0; i < _game.GameGrid.Columns; i++)
            {
                this.visualGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            _tiles = new Button[_game.GameGrid.Rows, _game.GameGrid.Columns];

            for (var row = 0; row < _game.GameGrid.Rows; row++)
            {
                for (var col = 0; col < _game.GameGrid.Columns; col++)
                {
                    var tile = new Button();
                    tile.SetValue(Grid.RowProperty, row);
                    tile.SetValue(Grid.ColumnProperty, col);
                    tile.Name = "GameButton";
                    tile.Click += GameButton_Click;
                    tile.BorderBrush = Brushes.Black;
                    tile.BorderThickness = new Thickness(1);
                    this.visualGrid.Children.Add(tile);
                    _tiles[row, col] = tile;
                }
            }
        }
        public void GameButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _game.GameGrid.Rows; i++)
                for (int j = 0; j < _game.GameGrid.Columns; j++)
                {
                    if (_tiles[i, j] == sender)
                    {
                        _tiles[i, j].IsHitTestVisible = false;
                        _game.Update(new Position(i, j));
                    }
                }
            DrawGrid(_game.GameGrid);
            int gameOver = _game.IsGameOver();
            if (gameOver != 0)
            {
                for (int i = 0; i < _game.GameGrid.Rows; i++)
                    for (int j = 0; j < _game.GameGrid.Columns; j++)
                    {
                        _tiles[i, j].IsHitTestVisible = false;
                    }
                this.txtGameOver.Text += gameOver;
            }            
        }

        public void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _game.Reset();
            for (int i = 0; i < _game.GameGrid.Rows; i++)
                for (int j = 0; j < _game.GameGrid.Columns; j++)
                {
                    _tiles[i, j].IsHitTestVisible = true;
                }
            this.txtGameOver.Text = "Winner:";
            DrawGrid(_game.GameGrid);
        }
    }
}
