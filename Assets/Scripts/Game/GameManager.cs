using System;
using System.Collections.Generic;
using System.Linq;
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
   public  List<GameObject> firstHalf = new List<GameObject>();
   public List<GameObject> secondHalf = new List<GameObject>();
    void Awake()
    {
        LevelManager = GetComponent<LevelManager>();
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
        EventSystem.PlayerDied += PlayerDied;
    }

    public void PlayerDied()
    {
        allcharacters.RemoveAll(c => c == null);
        int half = allcharacters.Count / 2;
        firstHalf = allcharacters.GetRange(0, half);
        secondHalf = allcharacters.GetRange(half,allcharacters.Count-half);
        for (int i = 0; i < firstHalf.Count; i++)
        {
            firstHalf[i].GetComponent<MeleeEnemy>().player = secondHalf[i];
            secondHalf[i].GetComponent<MeleeEnemy>().player = firstHalf[i];
        }
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
        int half = allcharacters.Count / 2;
        firstHalf = allcharacters.GetRange(0, half);
        secondHalf = allcharacters.GetRange(half,allcharacters.Count-half);
        for (int i = 0; i < firstHalf.Count; i++)
        {
            firstHalf[i].GetComponent<MeleeEnemy>().player = secondHalf[i];
            secondHalf[i].GetComponent<MeleeEnemy>().player = firstHalf[i];
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
