// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array for different enemy types
    public Transform[] spawnPoints;   // Points where enemies will spawn
    public int enemiesPerWave = 10;   // Total number of enemies per wave
    public int maxEnemies = 3;        // Maximum number of enemies at a time
    public float spawnDelay = 2f;     // Delay between spawns
    public int totalWaves = 3;        // Total number of waves
    public RoomManager roomManager;

//     private int enemiesSpawned = 0;
//     private int enemiesRemaining;
//     private int wavesCount = 0;
//     private bool isSpawning = false;

//     void Start()
//     {
//         enemiesRemaining = enemiesPerWave;
//     }

    public void StartSpawning()
    {
        if (!isSpawning && wavesCount < totalWaves)
        {
            isSpawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (wavesCount < totalWaves)
        {
            enemiesRemaining = enemiesPerWave; // Reset enemiesRemaining for the new wave
            while (enemiesRemaining > 0)
            {
                while (enemiesSpawned < maxEnemies && enemiesRemaining > 0)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(spawnDelay);
                }
                yield return null;
            }
            wavesCount++;
            yield return new WaitForSeconds(spawnDelay); // Delay between waves
        }
        // Unlock the room when all waves are finished
        if (roomManager != null)
        {
            roomManager.UnlockRoom();
        }
    }

//     void SpawnEnemy()
//     {
//         if (enemiesRemaining <= 0) return;

//         // Determine enemy type based on the current wave
//         GameObject enemyPrefab = GetEnemyTypeForWave();

//         Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
//         Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
//         enemiesSpawned++;
//         enemiesRemaining--;
//     }

//     GameObject GetEnemyTypeForWave()
//     {
//         if (wavesCount == 0)
//         {
//             return enemyPrefabs[0]; // First wave: only enemy1
//         }
//         else if (wavesCount == 1)
//         {
//             // Second wave: random between enemy1 and enemy2
//             int index = Random.Range(0, 1);
//             return enemyPrefabs[index];
//         }
//         else
//         {
//             // Third wave: random between enemy1, enemy2, and enemy3
//             int index = Random.Range(0, 2);
//             return enemyPrefabs[index];
//         }
//     }

//     public void EnemyDefeated()
//     {
//         enemiesSpawned--;
//     }
// }

