using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Enemy enemyData;
    // Current Stats
    float currMoveSpeed;
    float currHealth;
    float currDamage;
    // Start is called before the first frame update
    void Awake()
    {
        currMoveSpeed = enemyData.MoveSpeed;
        currHealth = enemyData.MaxHealth;
        currDamage = enemyData.Damage;
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
    protected virtual void OnTriggerEnter2D(Collider2D col){
        // hit player upon collision
        if(col.CompareTag("Player")){
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currDamage); //must stay currDamage in case of buffs
        }
    }
}
