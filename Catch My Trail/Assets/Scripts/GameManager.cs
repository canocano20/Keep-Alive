using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject spawner;
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
}
