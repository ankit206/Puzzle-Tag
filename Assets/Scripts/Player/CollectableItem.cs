using UnityEngine;

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
            Destroy(gameObject);
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
