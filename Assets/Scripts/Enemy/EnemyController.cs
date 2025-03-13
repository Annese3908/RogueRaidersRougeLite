using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;
    // Data for grub
   protected float currCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currCooldown = 5f;
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
        currCooldown = 5f;
   }
}
