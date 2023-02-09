using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[System.Serializable]
public class PlayerData
{
    public float timeString;
    public string playerPos;

    public PlayerData(string player, float gameTimer)
    {
        timeString = gameTimer;
        playerPos = player;
    }
}
