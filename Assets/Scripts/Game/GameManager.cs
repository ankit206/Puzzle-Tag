using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        SetFps();
    }

    // set appllication Framerate to 60
    void SetFps()
    {
        Application.targetFrameRate = 60;
    }
   
}
