using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveSystem 
{
    
    // to save player position, time and minimap
    
    public static void SaveGame(string playerMovement, float gameTimer, List<string> removed, string agent, List<string> keys)
    {
        PlayerData data = new PlayerData(playerMovement, gameTimer, removed, agent, keys);

        string JsonString = JsonUtility.ToJson(data);
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/JSONData.text");
        sw.Write(JsonString);
        sw.Close();
        
        
    }

    // if there is a game already played, load the saved data 

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/JSONData.text";
        
        
        if (File.Exists(path))
        {
            TestManagerScript.testinstance.isThereData = true;
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/JSONData.text");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            PlayerData data = JsonUtility.FromJson<PlayerData>(JsonString);
           
            return data;
        }
        else
        {
            TestManagerScript.testinstance.isThereData = false;
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    
}
