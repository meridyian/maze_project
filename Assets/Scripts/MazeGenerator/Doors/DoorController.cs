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
    private string collidedRoomName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            if (other.gameObject.transform.parent.name.StartsWith("Small Room"))
            {
                _requiredItem = InventoryManager.AllItems.smallRoomKey;
                if (HasRequiredItem(_requiredItem))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Debug.Log("Player just entered");
                    other.transform.GetChild(0).position = new Vector3(other.transform.GetChild(0).position.x, 1.5f,
                        other.transform.GetChild(0).position.z);
                   
                }
                else if (!HasRequiredItem(_requiredItem))
                {
                    
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
                
            }
            
            else if (other.gameObject.transform.parent.name.StartsWith("Big Room"))
            {
                _requiredItem = InventoryManager.AllItems.bigRoomKey;

                if (HasRequiredItem(_requiredItem))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    Debug.Log("Player entered to big room");
                    other.transform.GetChild(0).position = new Vector3(other.transform.GetChild(0).position.x, 1.5f,
                        other.transform.GetChild(0).position.z);
                    
                }
                else if(!HasRequiredItem(_requiredItem))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    
                }
            }
            
        }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            Debug.Log("player is going out");
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

