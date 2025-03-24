namespace TicTacToe_Gruppe2
{
    using System;

    /// <summary>
    /// Hauptklasse zur Steuerung des Tic-Tac-Toe-Spiels.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Der Einstiegspunkt des Programms.
        /// </summary>
        static void Main()
        {
            while (true) 
            {
                StartGame();
            }
        }

        /// <summary>
        /// Startet ein neues Spiel.
        /// </summary>
        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Willkommen zu Tic-Tac-Toe!");

            int size = SelectBoardSize();

            Console.Write("\nSpitzname für Spieler X: ");
            string playerX = Console.ReadLine()?.Trim();

            Console.Write("Spitzname für Spieler O: ");
            string playerO = Console.ReadLine()?.Trim();

            IDifficulty difficulty = size switch
            {
                3 => new SmallBoard(),
                5 => new LargeBoard(),
                7 => new HugeBoard(),
                _ => throw new InvalidOperationException("Ungültige Spielfeldgröße")
            };

            Model model = new Model(difficulty);
            View view = new View();
            Controller controller = new Controller(model, view);

            Console.Clear();
            Console.WriteLine($"Spiel gestartet! {playerX} spielt mit 'X', {playerO} spielt mit 'O'");

            PlayGame(controller, playerX, playerO);
        }


        /// <summary>
        /// Erlaubt die Auswahl der Spielfeldgröße.
        /// </summary>
        /// <returns>Die gewählte Spielfeldgröße.</returns>
        static int SelectBoardSize()
        {
            while (true)
            {
                Console.WriteLine("\nWählen Sie die Spielfeldgröße:");
                Console.WriteLine("1 - 3x3 (Small)");
                Console.WriteLine("2 - 5x5 (Large)");
                Console.WriteLine("3 - 7x7 (Huge)");

                Console.Write("\nIhre Auswahl (1/2/3): ");
                string input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        return 3;
                    case "2":
                        return 5;
                    case "3":
                        return 7;
                    default:
                        Console.WriteLine("\nUngültige Eingabe! Bitte wählen Sie 1, 2 oder 3.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }


        /// <summary>
        /// Steuert den Spielablauf.
        /// </summary>
        static void PlayGame(Controller controller, string playerX, string playerO)
        {
            while (true)
            {
                controller.UpdateView();

                Console.WriteLine("\n----------------------------------------------------");
                Console.WriteLine("Um den Spielzug rückgängig zu machen, drücke: U");
                Console.WriteLine("Um das Spiel zu beenden, drücke: E");
                Console.WriteLine("----------------------------------------------------");

                
                char winner = controller.GetWinner();
                if (winner != '\0') 
                {
                    Console.WriteLine($"\n {(winner == 'X' ? playerX : playerO)} hat gewonnen!");
                    Console.WriteLine("\n Du kannst weiterhin 'U' drücken, um den letzten Zug rückgängig zu machen.");
                }
                else
                {
                    Console.WriteLine($"\nAktueller Spieler: {(controller.GetCurrentPlayer() == 'X' ? playerX : playerO)}");
                }

                Console.Write("\nGeben Sie Ihren Zug im Format 'x y' ein (z. B. '1 2'): ");
                string input = Console.ReadLine()?.Trim();

                if (input.ToLower() == "e")
                {
                    Console.Clear();
                    Console.WriteLine("Spiel beendet. Zurück zur Spielfeldgrößenauswahl...");
                    break;
                }

                if (input.ToLower() == "u")
                {
                    if (controller.UndoMove())
                    {
                        Console.Clear();
                        continue;
                    }
                }

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2 ||
                    !int.TryParse(parts[0], out int x) ||
                    !int.TryParse(parts[1], out int y))
                {
                    Console.WriteLine("\n Ungültige Eingabe! Bitte verwenden Sie das Format 'x y'.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                int size = controller.GetBoardSize();
                if (x < 0 || x >= size || y < 0 || y >= size)
                {
                    Console.WriteLine($"\n Ungültige Eingabe! Werte müssen zwischen 0 und {size - 1} liegen.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                controller.MakeMove(x, y);

                winner = controller.GetWinner();
                if (winner != '\0')
                {
                    Console.Clear();
                    Console.WriteLine($"\n{(winner == 'X' ? playerX : playerO)} hat gewonnen!");
                    Console.WriteLine("\n Du kannst weiterhin 'U' drücken, um den letzten Zug rückgängig zu machen.");
                }

                Console.Clear();
            }

        }
    }
}
