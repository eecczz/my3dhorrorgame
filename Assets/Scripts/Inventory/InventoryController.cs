using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : SingletonBase<InventoryController>
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private int maxSlotCount = 6;
    private void Awake()
    {
        //inventory load+
    }

    private void LoadInventory(List<InventoryItem> inventory)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            this.inventory.Add(inventory[i]);
        }
    }

    public void AddItem(int itemId)
    {
        InventoryItem item = new InventoryItem(itemId, 1);
        if(inventory.Count == 0)
        { 
            inventory.Add(item);
            return;
        }
        else
        {
            for(int i=0; i < inventory.Count; i++)
            {
                if (inventory[i].itemId == itemId)
                {
                    inventory[i].itemCount++;
                    item = null;
                    break;
                }
            }
            if (item && inventory.Count < maxSlotCount) {
                inventory.Add(item);
            }
        }
    }

    private void RemoveItem(int index)
    {
        if (inventory[index].itemCount > 1)
        {
            inventory[index].itemCount--;
        }
        else
        {
            inventory.RemoveAt(index);
        }
    }
}
