using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class Definition for all weapons
public class AntWeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public Weapons weaponData;
    protected EnemyMovement em;
    protected AntAnimator antAnimator;
    float currCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        em = GetComponentInParent<EnemyMovement>();
        antAnimator = GetComponentInParent<AntAnimator>();
        currCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            antAnimator?.OnAttack();
            Attack();
        }
    }
    protected virtual void Attack(){
        currCooldown = weaponData.CooldownDuration;
    }
}

