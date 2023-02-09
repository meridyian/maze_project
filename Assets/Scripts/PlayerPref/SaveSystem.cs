using System;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(string playerMovement, string gameTimer)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/players.txt";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerMovement, gameTimer);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/players.txt";
        if (File.Exists(path))
        {
            Debug.Log("load okayy");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
