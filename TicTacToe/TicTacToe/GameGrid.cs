
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameGrid
    {
        private readonly int[,] _grid;

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
        public bool IsGridFull()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (_grid[i, j] == 0)
                        return false;
            return true;
        }
    }
}
