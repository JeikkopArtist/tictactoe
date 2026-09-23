using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardCell : MonoBehaviour
{
    [Header("Coordenadas en el Tablero")]
    [SerializeField] private int row;
    [SerializeField] private int col;

    [Header("Referencias Visuales")]
    [SerializeField] private TextMeshProUGUI cellText;

    private UIManager uiManager;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnCellClicked);

        // Buscamos el UIManager ascendiendo en la jerarquía (se encuentra en el Canvas)
        uiManager = GetComponentInParent<UIManager>();
        
        // debug: presentación
        Debug.Log("Soy el boton" + button.name + ", y tengo como pieza = '" + GameManager.Board[row, col] + "'");
    }

    private void OnCellClicked()
    {
        Debug.Log("Clickando el boton" + button.name);
        // 1. Intentamos la jugada en la lógica estática del juego
        if (GameManager.PlayMove(row, col))
        {
            // 2. Notificamos al UIManager que hemos encontrado en nuestro Canvas
            uiManager.UpdateUI();
        }
    }

    public void Refresh()
    {
        CellState state = GameManager.Board[row, col];
        cellText.text = (state == CellState.Empty) ? "" : state.ToString();
        // debug: presentación
        Debug.Log("Refrescando el boton" + button.name + ", y tengo como pieza = '" + GameManager.Board[row, col] + "'");
    }
}
