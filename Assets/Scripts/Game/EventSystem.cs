using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// To handel all events of game
public static  class EventSystem 
{
    public static Action<int> OnHealthChanged;
    public static Action OnHealthPostionused;
    public static Action<List<InventoryItem>> OnInventoryUpdated;

    public static Action ONStartGame;
    public static Action PlayerDied;
    public static Action disableStartGameUiPanel;
    public static Action FireArrow;
    public static Action OnLeveLComplete;
    public static Action LoadNextLevel;

    public static void StartGame()
    {
        ONStartGame?.Invoke();
        disableStartGameUiPanel?.Invoke();
    }

    public static void HealthPostionused()
    {
        OnHealthPostionused?.Invoke();
    }
    

}
