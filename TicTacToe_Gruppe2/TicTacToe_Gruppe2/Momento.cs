using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2
{
    public class GameMemento
    {
        public List<List<char>> State { get; }

        public GameMemento(List<List<char>> board)
        {
            State = board.Select(row => row.ToList()).ToList();
        }
    }
}
