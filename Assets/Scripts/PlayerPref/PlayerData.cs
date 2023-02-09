using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[System.Serializable]
public class PlayerData
{
    public string timeString;
    public string playerPos;

    public PlayerData(string player, string gameTimer)
    {
        timeString = gameTimer;
        playerPos = player;
    }
}
