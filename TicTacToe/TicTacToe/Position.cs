using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool IsValid()
        {
            return (Row >= 0 && Row < 3) && (Column >= 0 && Column < 3);
        }
    }
}