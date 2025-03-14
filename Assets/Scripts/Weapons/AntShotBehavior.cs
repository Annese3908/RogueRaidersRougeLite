using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntShotBehavior : ProjectileBehavior
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime; // set direction and speed of dagger
    }

    protected override void OnTriggerEnter2D(Collider2D col){
        // hit player
        if(col.CompareTag("Player")){
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currDamage); //must stay currDamage in case of buffs
        }
    }
}

