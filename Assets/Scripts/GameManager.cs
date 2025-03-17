using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // Required for UI buttons

public class GameManager : MonoBehaviour
{
    public GameObject roomsParent;
    public GameObject boss;
    public GameObject youWinPopup;
    public GameObject youLosePopup;
    private GameObject[] rooms;

    protected PlayerStats playerStats;
    private int clearedRooms = 0;
    private bool bossSpawned = false;

    void Start()
    {
        //boss.SetActive(false);
        playerStats = FindObjectOfType<PlayerStats>();

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
            spawnBoss();
        }
    }

    void spawnBoss()
    {
        Instantiate(boss);
        boss.transform.position = new Vector2(0f, 20f);
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
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
