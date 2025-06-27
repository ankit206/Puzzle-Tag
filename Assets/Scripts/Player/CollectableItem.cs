using UnityEngine;
//  class for collectables item 
public class CollectableItem : MonoBehaviour
{
    private string itemName = "Coin"; 
    private int itemValue = 1; 

    //item collected by trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectItem(this);
            }
            gameObject.SetActive(false);
        }
    }

    public int getItemValue()
    {
        return itemValue;
    }
    public string getitemName()
    {
        return itemName;
    }

    public void setItemValue(int value)
    {
        itemValue = value;
    }
}
