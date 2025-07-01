using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// class for invantory ui 
public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform contentPanel;
    
   
   // update invantry when new iten is collected 
   public void UpdateInventory(List<InventoryItem> inventory )
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject); // Clear old slots
        }

        foreach (var item in inventory)
        {
            GameObject slot = Instantiate(itemSlotPrefab, contentPanel);
            slot.GetComponentInChildren<Image>().sprite = item.icon;
            slot.GetComponentInChildren<ToolTip>().SetText(item.itemName, "Qty: " + item.quantity);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.quantity.ToString();
            slot.GetComponent<Button>().onClick.AddListener(EventSystem.HealthPostionused);
        }
    }
}
