using TMPro;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private int row;
    [SerializeField] private int col;

    [SerializeField] private TextMeshProUGUI cellText;
    
    
    
    // respuesta al onClick
    public void OnClick()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        } 
        
        // Intentar hacer la jugada
        GameManager.Instance.PlayMove(row, col);


    }

    public void Refresh()
    {
        CellState state = GameManager.Instance.Board[row, col];
        cellText.text = (state == CellState.Empty) ? "" : state.ToString();
    }
    
    
    private void Update()
    {
        Refresh();
    }   
}

        

    
    




