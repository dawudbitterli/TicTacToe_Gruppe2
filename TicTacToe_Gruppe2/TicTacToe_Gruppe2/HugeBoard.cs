using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2
{
    public class HugeBoard : IDifficulty
    {
        public int GetSize() => 7;
        public int GetWinCondition() => 4;
    }
}
