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
    }

    private void OnCellClicked()
    {
        // 1. Intentamos la jugada en la lógica estática del juego
        if (GameManager.PlayMove(row, col))
        {
            // 2. Notificamos al UIManager que hemos encontrado en nuestro Canvas
            uiManager.UpdateUI();
            // 3. Actualizar casilla con pieza del jugador (aunque el UIManager actualiza a todas en cada mano)
            Refresh();
        }
    }

    public void Refresh()
    {
        CellState state = GameManager.Board[row, col];
        cellText.text = (state == CellState.Empty) ? "" : state.ToString();
    }
}
