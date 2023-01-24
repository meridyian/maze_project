using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class RoomObj : MonoBehaviour
{
    private void Start()
    { 
        Debug.Log("Room created");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log(other.name);
        }
        
    }
}
