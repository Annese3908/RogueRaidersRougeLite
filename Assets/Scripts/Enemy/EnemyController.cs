using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;
    // Data for enemy
   protected float currCooldown;
   protected float currDamage;

    // Start is called before the first frame update
    void Awake(){
        currDamage = enemyData.Damage;
    }
    protected virtual void Start()
    {
        currCooldown = 3f;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            Attack();
        }
    }
   protected virtual void Attack(){
        currCooldown = 3f;
   }
   protected virtual void OnTriggerEnter2D(Collider2D col){

        // hit player upon collision
        if(currCooldown <= 0f){
            if(col.CompareTag("Player")){
                PlayerStats player = col.GetComponent<PlayerStats>();
                player.TakeDamage(currDamage); //must stay currDamage in case of buffs
            }
        }
    }
}
