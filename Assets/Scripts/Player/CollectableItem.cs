using UnityEngine;
//  class for collectables item 
public class CollectableItem : MonoBehaviour
{
    [Tooltip("The inventory item asset associated with this collectable")]
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
