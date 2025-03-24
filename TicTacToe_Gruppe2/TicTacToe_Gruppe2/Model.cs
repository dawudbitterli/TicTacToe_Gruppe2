namespace TicTacToe_Gruppe2

/// <summary>
/// Die Klasse Model repräsentiert das Spielfeld und die Spiellogik.
/// </summary>
{
    public class Model
    {
        private const char EmptyCell = '\0';

        public List<List<char>> Board { get; private set; }
        public char CurrentPlayer { get; private set; } = 'X';

        private List<GameMemento> history = new List<GameMemento>();
        private IDifficulty difficulty;


        /// <summary>
        /// Erstellt ein Model mit der gewählten Schwierigkeitsstufe.
        /// </summary>
        public Model(IDifficulty difficulty)
        {
            this.difficulty = difficulty;
            InitBoard();
        }

        public void InitBoard()
        {
            int size = difficulty.GetSize();
            Board = new List<List<char>>();
            for (int i = 0; i < size; i++)
            {
                Board.Add(new List<char>(new char[size]));
            }

            SaveState();
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
        }


        /// <summary>
        /// Führt einen Spielzug aus.
        /// </summary>
        /// <returns>True, wenn gültig.</returns>

        public bool SetMove(int x, int y)
        {
            int size = Board.Count;
            if (x < 0 || y < 0 || x >= size || y >= size || (Board[y][x] != EmptyCell))
                return false;

            Board[y][x] = CurrentPlayer;
            SaveState();
            SwitchPlayer();
            return true;
        }


        /// <summary>
        /// Prüft, ob es einen Gewinner gibt.
        /// </summary>
        public char CheckWinner()
        {
            int size = Board.Count;
            int winCondition = difficulty.GetWinCondition();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x <= size - winCondition; x++)
                {
                    char symbol = Board[y][x];
                    if (symbol != EmptyCell && Enumerable.Range(0, winCondition).All(i => Board[y][x + i] == symbol))
                    {
                        return symbol;
                    }
                }
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y <= size - winCondition; y++)
                {
                    char symbol = Board[y][x];
                    if (symbol != EmptyCell && Enumerable.Range(0, winCondition).All(i => Board[y + i][x] == symbol))
                    {
                        return symbol;
                    }
                }
            }

            for (int y = 0; y <= size - winCondition; y++)
            {
                for (int x = 0; x <= size - winCondition; x++)
                {
                    char symbol = Board[y][x];
                    if (symbol != EmptyCell && Enumerable.Range(0, winCondition).All(i => Board[y + i][x + i] == symbol))
                    {
                        return symbol;
                    }
                }
            }

            for (int y = 0; y <= size - winCondition; y++)
            {
                for (int x = winCondition - 1; x < size; x++)
                {
                    char symbol = Board[y][x];
                    if (symbol != EmptyCell && Enumerable.Range(0, winCondition).All(i => Board[y + i][x - i] == symbol))
                    {
                        return symbol;
                    }
                }
            }
            return EmptyCell; 
        }

        public void SaveState()
        {
            history.Add(new GameMemento(Board));
        }

        public bool CanUndo()
        {
            return history.Count > 1;
        }

        public void RestoreState()
        {
            if (history.Count > 1)
            {
                history.RemoveAt(history.Count - 1);
                Board = history[history.Count - 1].State.Select(row => row.ToList()).ToList();
                SwitchPlayer();
            }
        }

        public char GetWinner()
        {
            return this.CheckWinner();
        }
    }
}

