using System.Collections.Generic;
using UnityEngine;
// player inventory
public class PlayerInventory : MonoBehaviour
{
    // List of collected item names.
    public List<InventoryItem> collectedItems = new List<InventoryItem>(); 
    // Total score.
    public int totalScore = 0; 

    
    // updates the inventory.
    public void CollectItem(CollectableItem item)
    {
        if (item.item)
        {
            collectedItems.Add(item.item);
            
        }
        else
        {
            totalScore += item.item.quantity;
        }
        GameManager.Instance.uiManager.inventoryUI.UpdateInventory(collectedItems);
    }
}
