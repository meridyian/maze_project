using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[System.Serializable]
public class PlayerData
{
    public float timeString;
    public string playerPos;
    public List<GameObject> ceilings;

    public PlayerData(string player, float gameTimer, List<GameObject> removed)
    {
        ceilings = removed;
        timeString = gameTimer;
        playerPos = player;

    }
}
