using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private InventoryManager.AllKeys _itemType;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddKey(_itemType);
            gameObject.SetActive(false);
            //transform.parent.GetComponent<KeySwitch>().isKeyCollected = true;
        }
    }
    
}
