using UnityEngine;

public class SystemWOPR : MonoBehaviour
{
    public void Move(CellState piece)
    {
        // recorre el tablero (de forma lineal de arriba->abajo / izquierda -> derecha) y pone en la primera celda libre
        int i = 0;
        foreach (var cell in GameManager.Board)
        {
            if (cell == CellState.Empty)
            {
                // marca la celda correspondiente como ocupada (matriz 3 x 3)
                if (GameManager.PlayMove(i / 3, i % 3))
                {
                    break;
                }
            }
            i++;
        }
        
    }
}
