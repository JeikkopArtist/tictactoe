using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Referencias del Tablero")]
    [SerializeField] private BoardCell[] boardCells; // Las 9 casillas arrastradas al Inspector

    [Header("Interfaz de Estado")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button resetButton;

    [Header("Control de jugadores")] 
    [SerializeField] private SystemWOPR playerX = null;
    [SerializeField] private SystemWOPR playerO = null;

    private void Start()
    {
        resetButton.onClick.AddListener(RestartGame);
        RestartGame();
    }

    public void RestartGame()
    {
        GameManager.StartNewGame();
        UpdateUI();
    }

    public void UpdateUI()
    {
        // 1. Pedir a cada casilla que se actualice
        foreach (BoardCell cell in boardCells)
        {
            cell.Refresh();
        }

        // 2. Actualizar el texto del estado del juego
        if (GameManager.IsGameOver)
        {
            if (GameManager.Winner == CellState.Empty)
            {
                statusText.text = "¡Empate!";
            }
            else
            {
                statusText.text = $"¡Ganador: {GameManager.Winner}!";
            }
        }
        else
        {
            statusText.text = $"Turno actual: {GameManager.CurrentTurn}";
            // Si el turno actual es un jugador controlado por el sistema... "invitarle" a poner ficha
            if (GameManager.CurrentTurn == CellState.X)
            {
                if (playerX != null)
                {
                    playerX.Move(CellState.X);
                    UpdateUI();
                }
            }
            else if (GameManager.CurrentTurn == CellState.O)
            {
                if (playerO != null)
                {
                    playerO.Move(CellState.O);
                    UpdateUI();
                }
            }
        }
    }
}