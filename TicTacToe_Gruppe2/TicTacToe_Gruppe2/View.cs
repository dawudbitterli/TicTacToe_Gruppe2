using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Gruppe2

/// <summary>
/// Verwaltet die Darstellung des Spiels.
/// </summary>
{
    public class View
    {
        /// <summary>
        /// Zeigt das Spielfeld an.
        /// </summary>
        public void ShowBoard(List<List<char>> board)
        {
            int size = board.Count;

            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i}   ");
            }
            Console.WriteLine();

            for (int y = 0; y < size; y++)
            {
                Console.Write($"{y} "); 

                for (int x = 0; x < size; x++)
                {
                    char value = board[y][x] == '\0' ? ' ' : board[y][x];
                    Console.Write($" {value} ");
                    if (x < size - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();

                if (y < size - 1)
                {
                    Console.Write("  ");
                    for (int x = 0; x < size; x++)
                    {
                        Console.Write("---");
                        if (x < size - 1) Console.Write("+");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void ShowUndoSuccess()
        {
            Console.WriteLine("\nSpielzug wurde rückgängig gemacht.");
        }

        public void ShowPlayer(char player)
        {
            Console.WriteLine($"Aktueller Spieler: {player}");
        }

        public void ShowWin(char player)
        {
            Console.WriteLine($"Spieler {player} gewinnt!");
        }

        public void ShowError(string msg)
        {
            Console.WriteLine($"Fehler: {msg}");
        }
    }
}
