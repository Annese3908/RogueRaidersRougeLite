using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubBehavior : MonoBehaviour
{
    public Enemy enemyData;
    SpriteRenderer sr;
    Animator am;
    // Data for grub
    float currCooldown;
    float currDamage;

    // Start is called before the first frame update
    void Awake(){
        currDamage = enemyData.Damage;
    }
    void Start()
    {
        am = GetComponent<Animator>();
        currCooldown = 3f;
    }
    // Update is called once per frame
    void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            am.SetBool("Attacking", true);
            Attack();
           
        } else{
            am.SetBool("Attacking", false);
        }
    }
   void Attack(){
        currCooldown = 5f;
   }
    protected virtual void OnTriggerEnter2D(Collider2D col){
        // hit player upon collision
        if(col.CompareTag("Player")){
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currDamage); //must stay currDamage in case of buffs
        }
    }
}
