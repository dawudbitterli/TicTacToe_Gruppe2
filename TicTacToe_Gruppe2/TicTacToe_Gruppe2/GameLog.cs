using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2
{
    public sealed class GameLog
    {
        private static readonly GameLog instance = new GameLog();
        public static GameLog Instance => instance;
        private string logFile = "gamelog.txt";

        private GameLog() { }

        public void LogAction(string action)
        {
            Console.WriteLine("Log: " + action);
        }
    }
}
