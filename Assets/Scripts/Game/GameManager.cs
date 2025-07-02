using System;
using System.Collections.Generic;
using UnityEngine;
// manage Game States
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private GameObject player;
    
    public UIManager uiManager;
    
    public LevelManager LevelManager { get; private set; }
    public bool Gamestarted;
    public TopDownCamera Camera;
    
    public List<GameObject> chareaters = new List<GameObject>();
    public bool bettelArena;
    public List<GameObject> allcharacters = new List<GameObject>();
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
        SetFps();
        EventSystem.ONStartGame += StartGame;
    }
    // start game Hide Start screen
    public void StartGame()
    {
        Gamestarted = true;
        if (player!=null&& player.GetComponent<PlayerController>())
        {
            player.GetComponent<PlayerController>().isGamePaused  = false;
        }

        if (bettelArena)
        {
            allcharacters = LevelManager.spawnedEnemies;
        }
    }
    // set appllication Framerate to 60
    void SetFps()
    {
        Application.targetFrameRate = 60;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    public void setPlayer(GameObject playerobject)
    {
         player= playerobject;
         SetPlyerTocamera();
    }

    public void SetPlyerTocamera()
    {
        Camera.player = player.transform;
    }
    
   
}
