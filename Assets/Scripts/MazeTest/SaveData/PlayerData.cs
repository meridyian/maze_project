using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[System.Serializable]
public class PlayerData
{
    public float timeString;
    public string playerPos;
    public List<string> ceilings;

    public PlayerData(string player, float gameTimer, List<string> removed)
    {
        ceilings = removed;
        timeString = gameTimer;
        playerPos = player;

    }
}
