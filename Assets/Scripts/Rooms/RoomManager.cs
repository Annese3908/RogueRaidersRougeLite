using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Collider2D roomCollider;
    public EnemySpawner[] enemySpawners;
    public RoomDivider[] roomDividers;
    private bool roomLocked = false;
    private bool roomCleared = false;
    private GameManager gameManager;
    [SerializeField]
    private AudioSource audioPlayer;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        DebugClear();
        DebugUnlock();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !roomLocked && !roomCleared)
        {
            //Debug.Log("Player has entered " + gameObject.name);
            LockRoom();
        }
    }

    public void LockRoom()
    {
        roomLocked = true;

        for (int i = 0; i < roomDividers.Length; i++)
        {
            roomDividers[i].Toggle(true);
            audioPlayer.Play();
        }

        // Start spawning enemies
        foreach (var spawner in enemySpawners)
        {
            //spawner.StartSpawning();
        }
    }

    public bool IsReadyToUnlock()
    {
        return roomLocked & roomCleared;
    }

    // Call this method when all enemies in the room are defeated
    public void UnlockRoom()
    {
        for (int i = 0; i < roomDividers.Length; i++)
        {
            roomDividers[i].Toggle(false);
        }

        roomCollider.enabled = false;
        roomLocked = false;
        roomCleared = true;
        gameManager.RoomCleared();
        audioPlayer.Play();
    }

    public void SetRoomToClear()
    {
        roomCleared = true;
    }

    private void DebugClear()
    {
        if (roomLocked & Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log(gameObject.name + " is cleared");
            SetRoomToClear();
        }
    }

    private void DebugUnlock()
    {
        if (roomLocked & Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log(gameObject.name + " is unlocked");
            UnlockRoom();
        }
    }
}