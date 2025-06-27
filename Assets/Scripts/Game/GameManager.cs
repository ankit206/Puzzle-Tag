using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private GameObject player;
    
    public UIManager uiManager;
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
    }

    // set appllication Framerate to 60
    void SetFps()
    {
        Application.targetFrameRate = 60;
    }
   
}
