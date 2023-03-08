using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllKeys> _inventoryItems = new List<AllKeys>(); // all inventory items

    private void Awake()
    {
        Instance = this;
    }

    public void AddKey(AllKeys key)
    {
        if (!_inventoryItems.Contains(key))
        {
            _inventoryItems.Add(key);
        }
    }
    public void RemoveKey(AllKeys key)
    {
        if (_inventoryItems.Contains(key))
        {
            _inventoryItems.Remove(key);
        }
    }
    
    public enum AllKeys
    {
        Key1,
        Key2,
        Key3,
        Key4,
        Key5,
        Key6,
        Key7,
        Key8,
    }
}
