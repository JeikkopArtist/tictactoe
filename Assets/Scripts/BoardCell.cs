using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardCell : MonoBehaviour
{
    [SerializeField] public int row;
    [SerializeField] public int col;

    [SerializeField] private Sprite imageX;
    [SerializeField] private Sprite imageO;

    private Image _image;

    private Sprite _spriteDefault;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _spriteDefault = _image.sprite;
    }
    
    
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
        if ((state == CellState.X))
        {
            _image.sprite = imageX;
        }
        else if (state == CellState.O)
        {
            _image.sprite = imageO;
        }
        else
        {
            _image.sprite = _spriteDefault;
        }
    }
    
    
    private void Update()
    {
        Refresh();
    }   
}

        

    
    




