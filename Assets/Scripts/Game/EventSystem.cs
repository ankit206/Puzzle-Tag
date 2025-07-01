using System;
using UnityEngine;
using UnityEngine.Events;
// To handel all events of game
public static  class EventSystem 
{
    public static Action<int> OnHealthChanged;
    
    public static Action ONStartGame;
    // Handel Start game
    public static void StartGame()
    {
        ONStartGame?.Invoke();
        disableStartGameUiPanel?.Invoke();
    }
    // disable start game panel
    public static Action disableStartGameUiPanel;
    
    // handels Helth posion used
    public static Action OnHealthPostionused;
    public static void HealthPostionused()
    {
        OnHealthPostionused?.Invoke();
    }
}
