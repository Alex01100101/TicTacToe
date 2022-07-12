
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game : INotifyPropertyChanged
    {
        public GameGrid GameGrid { get; private set; }

        private bool _gameOver;
        public bool GameOver
        {
            get => _gameOver;
            private set
            {
                _gameOver = value;
                OnPropertyChanged(nameof(GameOver));
            }
        }

        public Game()
        {
            Reset();
        }

        public void Reset()
        {
            GameGrid = new GameGrid(3, 3);
            GameOver = false;
        }

        public int IsGameOver()
        {
            GameOver = true;
            int player = GameGrid.IsWin();
            if (player != 0)
                return player;
            if (GameGrid.IsGridFull())
                return 3;
            GameOver = false;
            return 0;
        }

        public Position EnemyTurn()
        {
            Position bestPosition = GameGrid.GetBestMove();
            Update(bestPosition,2);
            return bestPosition;
        }

        public void Update(Position pressedPosition,int player)
        {
            GameGrid[pressedPosition.Row, pressedPosition.Column] = player ;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
