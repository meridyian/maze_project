using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public int roomID;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            keyCollector.AddKey(roomID, gameObject);
            gameObject.SetActive(false);
        }
    }

}
