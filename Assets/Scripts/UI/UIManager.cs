using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Health UI")]
    public Slider healthBar;
    private static UIManager Instance; 
   
    public GameObject InventoryUIPanal;
    
    [Header("Player inventory")]
    public InventoryUI inventoryUI;
    [Header("Start Game  Button")]
    public Button StartGameButton;
    [Header("start Game panel")]
    public GameObject startGamepanel;

    [Header("lEVEL COMPLETE Panel")] 
    public GameObject completeLevel;
    public Button NextLevelButton;
    
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
        StartGameButton.onClick.AddListener(EventSystem.StartGame);
        NextLevelButton.onClick.AddListener(loadNextLevel);
        EventSystem.disableStartGameUiPanel += DisablStartGameUIPanle;
        EventSystem.OnLeveLComplete += OnLeveLComplete;
        EventSystem.LoadNextLevel += loadNextLevel;
    }

    private void OnLeveLComplete()
    {
        completeLevel.SetActive(false);
    }

    private void loadNextLevel()
    {
        completeLevel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggelInventrayPanal();
        }
    }
    // start game panel
    public void DisablStartGameUIPanle()
    {
        startGamepanel.SetActive(false);
    }
    // toggel inventray planel toggel on and of
    public void ToggelInventrayPanal()
    {
        InventoryUIPanal.SetActive(!InventoryUIPanal.activeInHierarchy);
    }
    
    private void OnEnable()
    {
        EventSystem.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        EventSystem.OnHealthChanged -= UpdateHealthBar;
    }
   // update player health bar
    private void UpdateHealthBar(int currentHP)
    {
        healthBar.value = currentHP;
    }
}
