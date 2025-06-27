using System;
using UnityEngine;

// class is for creating new items values that can be collected by player
[Serializable]
public class InventoryItem : MonoBehaviour
{ 
    public string itemName; 
    public Sprite icon; 
    public int quantity;
}
