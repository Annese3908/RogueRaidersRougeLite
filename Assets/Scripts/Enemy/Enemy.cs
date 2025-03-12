using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class Enemy : ScriptableObject {
    //base enemy stats
    [SerializeField]
    float damage;
    public float Damage{get => damage; private set => damage = value;}
     [SerializeField]
    float maxHealth;
    public float MaxHealth{get => maxHealth; private set => maxHealth = value;}
     [SerializeField]
    float moveSpeed;
    public float MoveSpeed{get => MoveSpeed; private set => MoveSpeed = value;}

}