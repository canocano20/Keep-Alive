using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_HoldTime", menuName = "TimeScore")]
public class SO_HoldTime : ScriptableObject
{   
    [SerializeField] private float currentScore;
    [SerializeField] private float highScore;

    public float CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
        }
    }

    public float HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }
}
