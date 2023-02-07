using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    // you can keep time
    public int key;

    
    // the values defined in thia constructor will be the default values
    // the game starts with when there's no data to load
    
    public GameData()
    {
        this.key = 0;
    }

}
