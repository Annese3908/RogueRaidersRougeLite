using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/Player", order = 0)]
public class Player : ScriptableObject
{

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    [SerializeField]
    int playerLives;
    public int PlayerLives { get => playerLives; private set => playerLives = value; }
    protected bool playerAlive;
    [SerializeField]
    int ammo;
    public int Ammo { get => ammo; private set => ammo = value; }

}