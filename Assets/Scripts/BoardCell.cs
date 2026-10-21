using TMPro;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private int row;
    [SerializeField] private int col;

    [SerializeField] private TextMeshProUGUI cellText;
    
    [SerializeField] private UIManager uiManager;
    
    // respuesta al onClick
    public void OnClick()
    {
        if (GameManager.IsGameOver)
        {
            return;
        } 
        
        // Intentar hacer la jugada
        if (GameManager.PlayMove(row, col))
        {
            uiManager.UpdateUI();
        }
    }

    public void Refresh()
    {
        CellState state = GameManager.Board[row, col];
        cellText.text = (state == CellState.Empty) ? "" : state.ToString();
    }
}
