using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public List<string> keys = new List<string>();
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keys.Add(gameObject.name);
            gameObject.SetActive(false);
        }
    }


}
