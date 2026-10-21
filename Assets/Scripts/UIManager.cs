using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private BoardCell[] boardsCell;

    [SerializeField] private TextMeshProUGUI statusText;
    
    
    void Start()
    {
        Reset();
    }
    
    // Gestión del click sobre el botón de RESET
    public void OnClickReset()
    {
        Reset();
    }

    private void Reset()
    {
        // Limpia el Tablero (modelo)
        GameManager.StartNewGame();
        // Actualiza la interface de usuario
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Actualiza el símbolo de cada celda en pantalla
        foreach (BoardCell boardCell in boardsCell)
        {
            boardCell.Refresh();
        }
        
        // Actualiza el texto de estado
        if (GameManager.IsGameOver)
        {
            // poner ganador o empate
            if (GameManager.Winner == CellState.Empty)
            {
                statusText.text = "¡ Empate !";
            }
            else
            {
                statusText.text = $"¡ Ganador: {GameManager.Winner} !";
            }
        }
        else
        {
            // informar del turno actual
            statusText.text = $"Turno actual: {GameManager.CurrentTurn}";
        }
    }
}
