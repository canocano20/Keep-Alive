using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    private TextMeshProUGUI _myText;
    void Start()
    {
        _myText = GetComponent<TextMeshProUGUI>();

        SetText();
    }

    public void SetText()
    {
        _myText.text = "High Score" + "\n" + GameManager.GetInstance().GetHighScore("HighScore");
    }

}
