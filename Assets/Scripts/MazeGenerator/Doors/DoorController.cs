using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // to open and close the door when player enters to the room
    // move the doors up
    // will be assigned to player
    
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Player just entered");
            other.transform.GetChild(0).position = new Vector3(other.transform.GetChild(0).position.x, 1.5f,
                other.transform.GetChild(0).position.z);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Close the door");
            other.transform.GetChild(0).position = new Vector3(other.transform.GetChild(0).position.x, 0.5f,
                other.transform.GetChild(0).position.z);
        }
    }

}

