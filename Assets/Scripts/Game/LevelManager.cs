using UnityEngine;
using System.Collections.Generic;
// manage Level Prefab Based on Game state
public class LevelManager : MonoBehaviour
{
    [Header("Level prefab List")]
    public GameObject[] levelPrefabs;
    [Header("Chracters")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    
    
    private GameObject currentLevelInstance;
    [Header("Current playert")]
    private GameObject playerInstance;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private Level currentLevelScript;

    public int currentLevelIndex { get; private set; } = 0;
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
        SpawnEnemies();

        Debug.Log($"Level {index} loaded.");
    }
    // spawn players
    private void SpawnPlayer()
    {
        if (currentLevelScript && playerPrefab)
        {
            playerInstance = Instantiate(playerPrefab, currentLevelScript.GetPlayerSpawnPoint().position, Quaternion.identity);
        }
    }
    // Spawn Enamy
    private void SpawnEnemies()
    {
        if (currentLevelScript && enemyPrefab)
        {
            foreach (var spawnPoint in currentLevelScript.GetEnemySpawnPoints())
            {
                var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
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
