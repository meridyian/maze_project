using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public int roomID;
    
    
    public void Start()
    {
        // get the roomIDs to match with keyIDs
        roomID = transform.parent.GetComponent<RoomObj>().roomId;
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //check if player has required key
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            
            if (keyCollector.keys.ContainsKey(roomID))
            {
                // add check for key move the door if it has key
                transform.GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("player can enter");
                transform.GetChild(0).position =
                    new Vector3(transform.GetChild(0).position.x, 1.5f, transform.GetChild(0).position.z);
            }
            else
            {
                transform.GetComponent<BoxCollider>().isTrigger = false;
            }

        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetComponent<BoxCollider>().isTrigger = true;
            Debug.Log("close the door");
            transform.GetChild(0).position = new Vector3(transform.GetChild(0).position.x, 0.5f,
                transform.GetChild(0).position.z);
        }
    }

    
}
