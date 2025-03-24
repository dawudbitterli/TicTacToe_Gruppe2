namespace TicTacToe_Gruppe2

/// <summary>
/// Die Klasse "Controller" steuert die Spiellogik und kommuniziert mit Model und View.
/// </summary>
{
    public class Controller
    {
        private Model model;
        private View view;


        /// <summary>
        /// Erstellt eine neue Instanz des Controllers.
        /// </summary>
        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;
        }
        public void StartGame()
        {
            model.InitBoard();
            UpdateView();
        }
        public char GetCurrentPlayer()
        {
            return model.CurrentPlayer;
        }


        /// <summary>
        /// Führt einen Spielzug aus.
        /// </summary>
        /// <param name="x">X-Koordinate des Zuges.</param>
        /// <param name="y">Y-Koordinate des Zuges.</param>
        public void MakeMove(int x, int y)
        {
            if (model.SetMove(x, y))
            {
                char winner = model.CheckWinner(); 
                if (winner != '\0') 
                {
                    view.ShowWin(winner);
                }
                UpdateView();
            }
            else
            {
                view.ShowError("Ungültiger Zug!");
            }
        }

        /// <summary>
        /// Macht den letzten Zug rückgängig.
        /// </summary>
        /// <returns>True, wenn erfolgreich.</returns>
        public bool UndoMove()
        {
            if (model.CanUndo())
            {
                model.RestoreState();
                UpdateView();
                view.ShowUndoSuccess();
                return true;
            }
            else
            {
                Console.WriteLine("\nKein vorheriger Spielzug vorhanden!");
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }

        public int GetBoardSize()
        {
            return model.Board.Count;
        }

        public void UpdateView()
        {
            view.ShowBoard(model.Board);
            view.ShowPlayer(model.CurrentPlayer);
        }


        /// <summary>
        /// Prüft, ob es einen Gewinner gibt.
        /// </summary>
        /// <returns>'X', 'O' oder '\0' (kein Gewinner).</returns>
        public char GetWinner()
        {
            return model.CheckWinner();
        }
    }
}
