using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2
{
    public interface IDifficulty
    {
        int GetSize();
        int GetWinCondition();
    }
}
