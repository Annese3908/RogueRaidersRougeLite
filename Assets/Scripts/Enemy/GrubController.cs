using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubController : EnemyController
{
    SpriteRenderer sr;
    Animator am;
    // Data for grub
    float currDamage;

    // Start is called before the first frame update
    void Awake(){
        currDamage = enemyData.Damage;
    }
    protected override void Start()
    {
        base.Start();
        am = GetComponent<Animator>();
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (currCooldown <= 0f){
            am.SetBool("Attacking", true);
            Attack();
           
        } else{
            am.SetBool("Attacking", false);
        }
    }
   protected override void Attack(){
        base.Attack();
   }
    protected virtual void OnTriggerEnter2D(Collider2D col){
        // hit player upon collision
        if(col.CompareTag("Player")){
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currDamage); //must stay currDamage in case of buffs
        }
    }
}
