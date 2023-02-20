using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;



public class DoorController : MonoBehaviour
{
    // to open and close the door when player enters to the room
    // move the doors up, collider should be seperated from object
    // will be assigned to player

    // check for which kind of item is required
    [SerializeField] private InventoryManager.AllItems _requiredItem;
    
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Door"))
        {
            // if player has the key of room type 
            if (HasRequiredItem(_requiredItem))
            {
                Debug.Log("Player just entered");
                other.transform.GetChild(0).position = new Vector3(other.transform.GetChild(0).position.x, 1.5f,
                    other.transform.GetChild(0).position.z);
            }
            
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


    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

