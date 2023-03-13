using System.Collections.Generic;


[System.Serializable]
public class PlayerData
{
    public float timeString;
    public string playerPos;
    public List<string> ceilings;
    public string agentposition;
    public List<string> keyList;

    // save player position, time and minimap
    public PlayerData(string player, float gameTimer, List<string> removed, string agent, List<string> keys)
    {
        ceilings = removed;
        timeString = gameTimer;
        playerPos = player;
        agentposition = agent;
        keyList = keys;


    }
}
