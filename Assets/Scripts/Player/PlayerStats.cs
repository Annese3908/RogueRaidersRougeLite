using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Player playerData;
    // Current Stats
    float currMoveSpeed;
    float currHealth;
    float currDamage;
    int currLives;
    int currAmmo;
    int currWater;
    // Start is called before the first frame update
    void Awake()
    {
        currMoveSpeed = playerData.MoveSpeed;
        currHealth = playerData.MaxHealth;
        currLives = playerData.PlayerLives;
        currAmmo = playerData.MaxAmmo;

        startingStatsDebug();
    }

    // Update is called once per frame
    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
        if (currHealth <= 0){
            Kill();
        }
    }

    public void Kill(){
        Destroy(gameObject);
    }

    public void FullHeal()
    {
        Debug.Log("Health is Full");
        currHealth = playerData.MaxHealth;
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
    }

    public void UseAmmo(int amount)
    {
        currAmmo -= amount;
    }

    public void CollectWater(int amount)
    {
        currWater += amount;
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
