using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
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
        _timeText.text = "Time: " + _timer;

        StartCoroutine(IncreaseTimer());
    }

    private void OnEnable()
    {
        _timer = 0;    

        StartCoroutine(IncreaseTimer());
    }

    private void OnDisable() 
    {
        _timer = 0;    
    }
}
