using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyCollector : MonoBehaviour
{
    public Dictionary<int, GameObject> keys = new Dictionary<int, GameObject>();
    
    public void AddKey(int roomID, GameObject keyObject) {
        keys.Add(roomID, keyObject);
        Debug.Log(roomID, keyObject);
    }
    
    public bool HasKey(int roomID) {
        return keys.ContainsKey(roomID);
    }
}
