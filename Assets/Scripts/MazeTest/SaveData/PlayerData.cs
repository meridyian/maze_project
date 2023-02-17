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
    public string agentposition;

    // save player position, time and minimap
    public PlayerData(string player, float gameTimer, List<string> removed, string agent)
    {
        ceilings = removed;
        timeString = gameTimer;
        playerPos = player;
        agentposition = agent;
        

    }
}
