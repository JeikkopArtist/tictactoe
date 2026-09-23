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

    private void Start()
    {
        Debug.Log("UIManager Starting...");
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
        }
    }
}