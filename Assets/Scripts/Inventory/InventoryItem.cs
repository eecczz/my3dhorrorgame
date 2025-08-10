using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int itemId;
    public int itemCount;

    public InventoryItem(int itemId, int itemCount)
    {
        this.itemId = itemId;
        this.itemCount = itemCount;
    }
}
