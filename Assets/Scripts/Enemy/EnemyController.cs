using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;
    // Data for enemy
    protected float currDamage;

    // Start is called before the first frame update
    void Awake(){
        currDamage = enemyData.Damage;
    }
  
    // Update is called once per frame
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            {
                PlayerStats player = col.GetComponent<PlayerStats>();
                if (player != null)
                {
                    player.TakeDamage(currDamage); // Apply damage to the player
                }
            }
    }
}

