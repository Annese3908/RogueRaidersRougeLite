using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Collider roomCollider;
    public EnemySpawner[] enemySpawners;
    private bool roomLocked = false;
    private bool roomCleared = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

//     // create bool variable to see if room is locked, initially start as false
//     private bool roomLocked = false;
/*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !roomLocked && !roomCleared)
        {
            roomLocked = true;
            roomCollider.enabled = true;

            // Start spawning enemies
            foreach (var spawner in enemySpawners)
            {
                spawner.StartSpawning();
            }
        }
    }

    // Call this method when all enemies in the room are defeated
    public void UnlockRoom()
    {
        roomCollider.enabled = false;
        roomLocked = false;
        roomCleared = true;
        gameManager.RoomCleared();
    }
}
*/
//     public void UnlockRoom()
//     {
//         roomCollider.enabled = false;
//         roomLocked = false;
//     }
}
