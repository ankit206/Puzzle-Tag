using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// manage Level Prefab Based on Game state
public class LevelManager : MonoBehaviour
{
    [Header("Level prefab List")]
    [SerializeField] private GameObject[] levelPrefabs;
    [Header("Chracters")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private  List<GameObject> enemyPrefab = new List<GameObject>();
    
    
    private GameObject currentLevelInstance;
    [Header("Current playert")]
    public GameObject playerInstance;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private Level currentLevelScript;
    public List<Transform> enemywayPoints;
    public bool THirdPersonGame;
    public int currentLevelIndex { get; private set; } = 0;

    private void Start()
    {
        LoadLevel(0);
        EventSystem.LoadNextLevel += LoadNextLevel;
        
    }
    private void OnDestroy()
    {
        EventSystem.LoadNextLevel -= LoadNextLevel;
    }
    // Load Levels
    public void LoadLevel(int index)
    {
        if (index < 0 || index >= levelPrefabs.Length)
        {
            Debug.LogWarning("Invalid level index.");
            return;
        }

        UnloadCurrentLevel();

        currentLevelInstance = Instantiate(levelPrefabs[index]);
        currentLevelScript = currentLevelInstance.GetComponent<Level>();
        currentLevelIndex = index;

        SpawnPlayer();
        

        Debug.Log($"Level {index} loaded.");
    }
    // spawn players
    private void SpawnPlayer()
    {
        if (THirdPersonGame)
        {
            if (currentLevelScript && playerPrefab)
            {
                playerInstance = Instantiate(playerPrefab, currentLevelScript.GetPlayerSpawnPoint().position, Quaternion.identity);
            }
            GameManager.Instance.setPlayer(playerInstance);
        }
        SpawnEnemies();
    }
    // Spawn Enamy
    private void SpawnEnemies()
    {
        if (currentLevelScript)
        {
            for (int i = 0; i < enemyPrefab.Count; i++) 
            {
                var enemy = Instantiate(enemyPrefab[i], currentLevelScript.enemySpawnPoints[i].position, Quaternion.identity);
                spawnedEnemies.Add(enemy);
            }
        }
    }

    public void UnloadCurrentLevel()
    {
        if (playerInstance != null)
            Destroy(playerInstance);

        foreach (var enemy in spawnedEnemies)
            if (enemy != null) Destroy(enemy);

        spawnedEnemies.Clear();

        if (currentLevelInstance != null)
            Destroy(currentLevelInstance);

        currentLevelScript = null;
    }

    public void LoadNextLevel() => LoadLevel(currentLevelIndex + 1);
    public void ReloadLevel() => LoadLevel(currentLevelIndex);
}
