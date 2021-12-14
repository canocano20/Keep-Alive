using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject spawner;

    private void Start()
    {
        AudioManager.GetInstance().Play("Background");
        Application.targetFrameRate = 60;
    } 
    public void OnGameStart()
    {
        player.SetActive(true);
        spawner.SetActive(true);
    }

    public void OnGameEnded()
    {
        player.SetActive(false);
        spawner.SetActive(false);
    }


    public void SetHighScore(string name ,int score)
    {
        PlayerPrefs.SetInt(name, score);
    }

    public int GetHighScore(string name)
    {
        int highScore = PlayerPrefs.GetInt(name);
        return highScore;
    }
}
