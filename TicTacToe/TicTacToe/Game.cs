
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
        private int _player;

        public int Player
        {
            get => _player;
            private set
            {
                _player = value;
            }
        }

        public Game()
        {
            Reset();
        }

        public void Reset()
        {
            GameGrid = new GameGrid(3, 3);
            _player = 1;
            GameOver = false;
        }

        public int IsGameOver()
        {
            int player;
            GameOver = true;
            for (int i = 0; i < 3; i++)
            {
                player = GameGrid.IsRowWin(i);
                if (player != 0)
                    return player;
            }
            for (int i = 0; i < 3; i++)
            {
                player = GameGrid.IsColumnWin(i);
                if (player != 0)
                    return player;
            }
            player = GameGrid.IsFirstDiagonalWin();
            if (player != 0)
                return player;
            player = GameGrid.IsSecondDiagonalWin();
            if (player != 0)
                return player;
            GameOver = false;
            return 0;
        }

        public void Update(Position pressedPosition)
        {
            GameGrid[pressedPosition.Row, pressedPosition.Column] = _player;
            if (_player == 1)
                _player = 2;
            else
                _player = 1;
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
