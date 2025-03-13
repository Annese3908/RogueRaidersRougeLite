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
        float dirX = direction.x;
        float dirY = direction.y;
        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirX < 0 && dirY == 0){ //Left
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        } else if(dirX == 0 && dirY < 0){ //Down
            scale.y = scale.y * -1;
        }else if(dirX == 0 && dirY > 0){ //Up
            scale.x = scale.x * -1;
        }else if(dirX > 0 && dirY > 0){ //RightUp
            rotation.z = 0f;
        }else if(dirX > 0 && dirY < 0){ //RightDown
            rotation.z = -90f;
        }else if(dirX < 0 && dirY > 0){ //LeftUp
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }else if(dirX < 0 && dirY < 0){ //LeftDown
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); //cannot convert vector
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
