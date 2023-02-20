using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // make it static, it will be in one shape
    // inventory will be held in a list
    
    public static InventoryManager Instance;
    public List<AllItems> _inventoryItems = new List<AllItems>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) // add items to inventory
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }
    
    public void RemoveItem(AllItems item) // remove items from inventory
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }
    
    
    // all available inventory items in game, enums can be also used to keep states
    public enum AllItems
    {
        smallRoomKey,
        bigRoomKey
    }

}
