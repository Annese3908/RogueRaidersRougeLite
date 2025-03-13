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
    // Start is called before the first frame update
    void Awake()
    {
        currMoveSpeed = playerData.MoveSpeed;
        currHealth = playerData.MaxHealth;
        currLives = playerData.PlayerLives;
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
}
