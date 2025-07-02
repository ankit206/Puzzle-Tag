using System;
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
        player.GetComponent<PlayerController>().GamePaused  = false;
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
