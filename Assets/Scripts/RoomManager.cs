using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] roomPrefab;
    // create variables for collider and enemyspawner list
    public Collider roomCollider;
    public EnemySpawner[] enemySpawners;

    // create bool variable to see if room is locked, initially start as false
    private bool roomLocked = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !roomLocked)
        {
            roomLocked = true;
            roomCollider.enabled = true;

            //start spawning enemies
            foreach (var spawner in enemySpawners)
            {
                spawner.StartSpawning();
            }
        }
    }

    public void UnlockRoom()
    {
        roomCollider.enabled = false;
        roomLocked = false;
    }
}
