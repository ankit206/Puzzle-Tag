using System;
using UnityEngine;

// class is for creating new items values that can be collected by player
[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item")]
public class InventoryItem : ScriptableObject
{ 
    public string itemName; 
    public Sprite icon; 
    public int quantity;
}
