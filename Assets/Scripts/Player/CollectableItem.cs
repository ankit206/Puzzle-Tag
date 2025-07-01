using UnityEngine;
//  class for collectables item 
public class CollectableItem : MonoBehaviour
{
    public InventoryItem item;
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
}
