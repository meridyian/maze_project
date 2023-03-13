using System.Collections.Generic;
using UnityEngine;


public class KeyCollector : MonoBehaviour
{
    public Dictionary<int, GameObject> keys = new Dictionary<int, GameObject>();
    
    // add keys to dictionary
    public void AddKey(int roomID, GameObject keyObject) {
        keys.Add(roomID, keyObject);
        Debug.Log(roomID, keyObject);
    }
    
}
