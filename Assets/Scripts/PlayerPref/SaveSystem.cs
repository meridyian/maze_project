using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SaveSystem 
{
    
    
    public static void SavePlayer(string playerMovement, float gameTimer, List<GameObject> removed)
    {
        //BinaryFormatter formatter = new BinaryFormatter();

        //string path = Application.persistentDataPath + "/players.json";

        //FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerMovement, gameTimer, removed);

        string JsonString = JsonUtility.ToJson(data);
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/JSONData.text");
        sw.Write(JsonString);
        sw.Close();
        //formatter.Serialize(stream, data);
        
    }

    

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/JSONData.text";
        
        
        if (File.Exists(path))
        {
            TestManagerScript.testinstance.isThereData = true;
            //Load the game data
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/JSONData.text");
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(path, FileMode.Open);
            string JsonString = sr.ReadToEnd();
            sr.Close();
            PlayerData data = JsonUtility.FromJson<PlayerData>(JsonString);
            //stream.Close();
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
