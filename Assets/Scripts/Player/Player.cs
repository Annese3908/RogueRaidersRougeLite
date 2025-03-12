using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHP;
    public int hp;

    [SerializeField] private int maxAmmo;
    public float ammo;

    [SerializeField] private int waterPerBucket;
    private int maxWater;
    public int water;

    public int GetMaxHP()
    {
        return maxHP;
    }

    public void healthUpdate (int amount)
    {
        hp += amount;

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp < 0)
        {
            //die
        }
    }

    public void FullHeal ()
    {
        hp = maxHP;
    }

    public void IncreaseMaxHP (int amount)
    {
        maxHP += amount;
        hp += amount;
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }

    public void RefillAmmo()
    {
        ammo = maxAmmo;
    }

    public int FullBucketCount()
    {
        return water / waterPerBucket;
    }

    public void SpendBucket()
    {
        water -= waterPerBucket;
    }

    public void Start()
    {
        maxWater = waterPerBucket * 3;
    }
}
