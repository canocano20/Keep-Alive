using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private SO_HoldTime _holdTime;
    private TextMeshProUGUI _timeText;
    private int _timer;
    private void Start() 
    {
        _timeText = GetComponent<TextMeshProUGUI>();    
        _timer = 0;
    }

    IEnumerator IncreaseTimer()
    {
        yield return new WaitForSeconds(1f);
        _timer += 1;
        _timeText.text = _timer.ToString();

        StartCoroutine(IncreaseTimer());
    }

    private void OnEnable()
    {
        _timer = 0;   
    
        StartCoroutine(IncreaseTimer());
    }

    public void OnGameEnded() 
    {
        _timeText.text = "0";

        if(_timer != 0)
            _holdTime.CurrentScore = _timer;

        if(_holdTime.CurrentScore > _holdTime.HighScore)
            _holdTime.HighScore = _holdTime.CurrentScore;
        
        _timer = 0;
    }

    
}
