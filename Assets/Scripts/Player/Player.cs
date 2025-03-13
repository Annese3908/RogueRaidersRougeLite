using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/Player", order = 0)]
public class Player : ScriptableObject
{

    [SerializeField]
    int maxHealth;
    public int MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    [SerializeField]
    int playerLives;
    public int PlayerLives { get => playerLives; private set => playerLives = value; }
    protected bool playerAlive;
    [SerializeField]
    int maxAmmo;
    public int MaxAmmo { get => maxAmmo; private set =>maxAmmo = value; }
    [SerializeField]
    int buckets;
    public int Buckets { get => buckets; private set => buckets = value; }
    [SerializeField]
    int waterPerBucket;
    public int WaterPerBucket { get => waterPerBucket; private set => waterPerBucket = value; }
    public int MaxWater { get => buckets * waterPerBucket; }

}