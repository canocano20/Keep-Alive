using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    [SerializeField] SO_HoldTime _holdTime;
    
    [SerializeField] bool _isHighScore;
    private TextMeshProUGUI _textMeshPro;

    

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void SetTextMeshPro(float score)
    {
        _textMeshPro.text = score.ToString();
    }
   
    private void OnEnable()
    {
        if(_isHighScore)
            SetTextMeshPro(GameManager.GetInstance().GetHighScore("HighScore"));

        else if(!_isHighScore)
            SetTextMeshPro(_holdTime.CurrentScore);
    }
}
