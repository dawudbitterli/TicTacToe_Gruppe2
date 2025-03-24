using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2
{
    public class SmallBoard : IDifficulty
    {
        public int GetSize() => 3;
        public int GetWinCondition() => 3;
    }
}
