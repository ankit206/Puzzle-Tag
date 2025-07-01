using UnityEngine;
using System.Collections.Generic;
// Level Script To handel Level Prefab
public class Level : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform playerSpawnPoint;
    public List<Transform> enemySpawnPoints;

    public Transform GetPlayerSpawnPoint()
    {
        return playerSpawnPoint;
    }

    public List<Transform> GetEnemySpawnPoints()
    {
        return enemySpawnPoints;
    }
}