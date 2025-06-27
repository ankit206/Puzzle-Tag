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
        if (item.gameObject.GetComponent<InventoryItem>())
        {
            collectedItems.Add(item.gameObject.GetComponent<InventoryItem>());
            
        }
        else
        {
            totalScore += item.getItemValue();
        }
        Debug.Log($"Collected: {item.getItemValue()} | Total Score: {totalScore}");
        GameManager.Instance.uiManager.inventoryUI.UpdateInventory(collectedItems);
    }
}
