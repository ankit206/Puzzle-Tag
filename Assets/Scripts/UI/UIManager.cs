using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance; 
   
    public GameObject InventoryUIPanal;
    
    public PlayerInventory playerInventory;
    
    public InventoryUI inventoryUI;
    // Createing Singelton UIManager
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggelInventrayPanal();
        }
    }

    public void ToggelInventrayPanal()
    {
        InventoryUIPanal.SetActive(!InventoryUIPanal.activeInHierarchy);
    }
}
