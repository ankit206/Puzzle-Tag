using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // List of collected item names.
    public List<string> collectedItems = new List<string>(); 
    // Total score.
    public int totalScore = 0; 

    
    // updates the inventory.
    public void CollectItem(CollectableItem item)
    {
        collectedItems.Add(item.getitemName());
        totalScore += item.getItemValue();

        Debug.Log($"Collected: {item.getItemValue()} | Total Score: {totalScore}");
    }
}
