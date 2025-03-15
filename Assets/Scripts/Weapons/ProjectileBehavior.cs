using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Predefined Behaviors for projectile weapons
public class ProjectileBehavior : MonoBehaviour
{
    public Weapons weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;
    //Current Stats
    protected float currDamage;
    protected float currSpeed;
    protected float currCooldown;
    protected int currPierce;
    // Start is called before the first frame update

    void Awake(){
        currDamage = weaponData.Damage;
        currSpeed = weaponData.Speed;
        currCooldown = weaponData.CooldownDuration;
        currPierce = weaponData.Pierce;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    public void DirectionCheck(Vector3 dir)
    {
        direction = dir;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col){
        // hit enemy
        if(col.CompareTag("Enemy")){
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currDamage); //must stay currDamage in case of buffs
            ReducePierce();
        }
    }
    void ReducePierce() //control how many times a weapon can hit before deleting
    {
        if(currPierce <= 0){
            Destroy(gameObject);
        }
    }
}
