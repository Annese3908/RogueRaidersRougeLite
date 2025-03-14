using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject roomsParent;
    public GameObject boss;
    public GameObject youWinPopup;
    public GameObject youLosePopup;
    private GameObject[] rooms;
    private int clearedRooms = 0;
    private bool bossSpawned = false;

    void Start()
    {
        //boss.SetActive(false);

        // Get all child objects of roomsParent and store them in the rooms array
        int childCount = roomsParent.transform.childCount;
        rooms = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            rooms[i] = roomsParent.transform.GetChild(i).gameObject;
        }
    }

    public void RoomCleared()
    {
        clearedRooms++;
        checkForBossSpawn();
    }

    public void PlayerEnteredSpawnRoom()
    {
        checkForBossSpawn();
    }

    void checkForBossSpawn()
    {
        if (clearedRooms >= 3 && !bossSpawned)
        {
            //spawnBoss();
        }
    }

    void spawnBoss()
    {
        boss.SetActive(true);
        bossSpawned = true;
    }

    public void PlayerWin()
    {
        youWinPopup.SetActive(true);
        // add more code to allow player to restart game or exit game
    }

    public void PlayerLose()
    {
        youLosePopup.SetActive(true);
        // add more code to allow player to restart game or exit game
    }
}
