
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameGrid
    {
        private int[,] _grid;

        public int Rows { get; }

        public int Columns { get; }

        public int this[int r, int c]
        {
            get => _grid[r, c];
            set => _grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows=rows;
            Columns = columns;
            _grid = new int[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    _grid[i, j] = 0;
        }

        public int IsRowWin(int row)
        {
            int player = _grid[row, 0];
            for (int i = 0; i < Columns; i++)
                if (_grid[row, i] != player)
                    return 0;
            return player;
        }

        public int IsColumnWin(int column)
        {
            int player = _grid[0, column];
            for (int i = 0; i < Rows; i++)
                if (_grid[i, column] != player)
                    return 0;
            return player;
        }

        public int IsFirstDiagonalWin()
        {
            int player = _grid[0, 0];
            for (int i = 0; i < Columns; i++)
                if (_grid[i, i] != player)
                    return 0;
            return player;
        }

        public int IsSecondDiagonalWin()
        {
            int player = _grid[0, Columns-1];
            for (int i = 0; i < Rows; i++)
                if (_grid[i, Columns-i-1] != player)
                    return 0;
            return player;
        }

        public int IsWin()
        {
            int player;
            for (int i = 0; i < 3; i++)
            {
                player = IsRowWin(i);
                if (player != 0)
                    return player;
            }
            for (int i = 0; i < 3; i++)
            {
                player =IsColumnWin(i);
                if (player != 0)
                    return player;
            }
            player = IsFirstDiagonalWin();
            if (player != 0)
                return player;
            player =IsSecondDiagonalWin();
            if (player != 0)
                return player;
            return 0;
        }

        public bool IsGridFull()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (_grid[i, j] == 0)
                        return false;
            return true;
        }

        public Position GetBestMove()
        {
            Position bestPosition = new Position(1, 1);
            int score = -200;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (_grid[i, j] == 0)
                    {
                        int temp = GetScore(new Position(i, j),2);
                        if(temp>score)
                        {
                            score = temp;
                            bestPosition = new Position(i, j);
                        }
                    }
            return bestPosition;
        }

        public int GetScore(Position position, int player)
        {
            int score=0;
            _grid[position.Row, position.Column] = player;
            if (IsWin() == 2)
            {
                _grid[position.Row, position.Column] = 0;
                return 100;
            }
            if (IsWin() == 1)
            {
                _grid[position.Row, position.Column] = 0;
                return -100;
            }
            if (IsGridFull())
            {
                _grid[position.Row, position.Column] = 0;
                return 0;
            }
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (_grid[i, j] == 0)
                    {
                        int temp;
                        if (player==1)
                            temp = GetScore(new Position(i, j),2);
                        else
                            temp = GetScore(new Position(i, j),1);
                        if (temp >0)
                        {
                            score += 10;
                        }
                        else if (temp <0)
                            score -= 10;
                        else score += temp;
                    }
            _grid[position.Row, position.Column] = 0;
            return score;
        }
    }
}
