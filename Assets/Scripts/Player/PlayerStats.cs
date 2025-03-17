using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Player playerData;
    public AudioSource audioPlayer;
    public AudioClip bite, spray, reload, bubble;
    // Current Stats
    float currMoveSpeed;
    float currHealth;
    float currDamage;
    int currLives;
    int currAmmo;
    int currWater;
    Transform respawnPoint;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        currMoveSpeed = playerData.MoveSpeed;
        currHealth = playerData.MaxHealth;
        currLives = playerData.PlayerLives;
        currAmmo = playerData.MaxAmmo;
        respawnPoint.position = Vector3.zero;
        gameManager = FindObjectOfType<GameManager>();

        startingStatsDebug();
    }

    // Update is called once per frame
    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
        if (currHealth <= 0)
        {
            currHealth = 0;
            Kill();
        }
        FindObjectOfType<HeartScript>().DrawHeart();
        audioPlayer.clip = bite;
        audioPlayer.Play();
    }

    public void Kill(){
        if (currLives > 0){
            Respawn();
        } else{
            // No lives left, destroy the player
            gameManager.PlayerLose();
            FindObjectOfType<GameManager>().PlayerLose();
            Destroy(gameObject);
            Debug.Log("Game Over! No lives remaining.");
        }
    }

    public void Respawn()
    {
        // Decrease lives
        currLives--;
        // Reset health
        currHealth = playerData.MaxHealth;
        // Move the player to the respawn point
        if (respawnPoint != null){
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
        } else{
            Debug.LogWarning("Respawn point not set! Respawning at original position.");
        }

        Debug.Log("Player respawned! Lives remaining: " + currLives);
    }


    public void FullHeal()
    {
        Debug.Log("Health is Full");
        currHealth = playerData.MaxHealth;
        audioPlayer.clip = bite;
        audioPlayer.Play();
    }

    public bool AtFullHealth()
    {
        return currHealth == playerData.MaxHealth;
    }
    public int Health()
    {
        return (int)currHealth;
    }

    public void RefillAmmo()
    {
        Debug.Log("Ammo is refilled");
        currAmmo = playerData.MaxAmmo;

        audioPlayer.clip = reload;
        audioPlayer.Play();
    }

    public void UseAmmo(int amount)
    {
        currAmmo -= amount;

        audioPlayer.clip = spray;
        audioPlayer.Play();
    }

    public void CollectWater(int amount)
    {
        if (currWater < playerData.MaxWater)
        {
            currWater += amount;
            audioPlayer.clip = bubble;
            audioPlayer.Play();
        }
    }

    public void SpendBucket()
    {
        if (currWater >= playerData.WaterPerBucket)
            currWater -= playerData.WaterPerBucket;
    }

    public int FilledBuckets()
    {
        return currWater / playerData.WaterPerBucket;
    }

    public bool AtFullAmmo()
    {
        return currAmmo == playerData.MaxAmmo;
    }

    public int Ammo()
    {
        return currAmmo;
    }

    private void startingStatsDebug()
    {
        currHealth = playerData.MaxHealth / 2;
        currAmmo = playerData.MaxAmmo / 2;
        currWater = (int)(playerData.WaterPerBucket * 3);
    }
}
