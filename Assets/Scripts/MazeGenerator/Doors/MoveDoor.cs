using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public int roomID;

    public void Start()
    {
        roomID = transform.parent.GetComponent<RoomObj>().roomId;
    }
 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            
            //check if player has required key
            if (keyCollector.keys.ContainsKey(roomID))
            {
                // add check for key
                transform.GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("player just entered");
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
            Debug.Log("player is going out");
            transform.GetChild(0).position = new Vector3(transform.GetChild(0).position.x, 0.5f,
                transform.GetChild(0).position.z);
        }
    }

    
}
