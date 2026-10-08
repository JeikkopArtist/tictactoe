public enum CellState { Empty, X, O }

public enum Player { Human, System }

public static class GameManager
{
    // Tablero de 3x3
    public static CellState[,] Board { get; private set; } = new CellState[3, 3];
    public static CellState CurrentTurn { get; private set; } = CellState.X;
    public static bool IsGameOver { get; private set; }
    public static CellState Winner { get; private set; } = CellState.Empty;

    // Inicializa o reinicia la partida
    public static void StartNewGame()
    {
        Board = new CellState[3, 3];
        CurrentTurn = CellState.X;
        IsGameOver = false;
        Winner = CellState.Empty;
    }

    // Intenta realizar una jugada en la posición (row, col)
    public static bool PlayMove(int row, int col)
    {
        // Validar si el juego terminó o la casilla ya está ocupada
        if (IsGameOver || Board[row, col] != CellState.Empty)
            return false;

        // Registrar la jugada
        Board[row, col] = CurrentTurn;

        // Comprobar estado de la partida
        if (CheckWin(row, col))
        {
            IsGameOver = true;
            Winner = CurrentTurn;
        }
        else if (IsBoardFull())
        {
            IsGameOver = true;
            Winner = CellState.Empty; // Empate
        }
        else
        {
            // Cambiar turno
            CurrentTurn = (CurrentTurn == CellState.X) ? CellState.O : CellState.X;
        }

        return true;
    }

    private static bool CheckWin(int row, int col)
    {
        // Comprobar fila
        if (Board[row, 0] == CurrentTurn && Board[row, 1] == CurrentTurn && Board[row, 2] == CurrentTurn) 
            return true;

        // Comprobar columna
        if (Board[0, col] == CurrentTurn && Board[1, col] == CurrentTurn && Board[2, col] == CurrentTurn) 
            return true;

        // Comprobar diagonal principal
        if (row == col && Board[0, 0] == CurrentTurn && Board[1, 1] == CurrentTurn && Board[2, 2] == CurrentTurn) 
            return true;

        // Comprobar diagonal secundaria
        if (row + col == 2 && Board[0, 2] == CurrentTurn && Board[1, 1] == CurrentTurn && Board[2, 0] == CurrentTurn) 
            return true;

        return false;
    }

    private static bool IsBoardFull()
    {
        foreach (CellState cell in Board)
        {
            if (cell == CellState.Empty) return false;
        }
        return true;
    }
}
