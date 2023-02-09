using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


[System.Serializable]
public class PlayerData
{
    public string timeString;
    public string playerPos;
    public float[] position;

    public PlayerData(string player, string gameTimer)
    {
        timeString = gameTimer;
        //position = new float[3];
        playerPos = player;

        /*
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
   */
    }
}
