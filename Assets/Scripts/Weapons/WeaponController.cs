using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class Definition for all weapons
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public Weapons weaponData;
    public Player playerData;
    protected PlayerMovement pm;
    protected PlayerAnimator pa;
    float currCooldown;
    int currAmmo;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        pa = pm.GetComponent<PlayerAnimator>();
        currAmmo = playerData.MaxAmmo;
        currCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0)){
            if (currCooldown <= 0f && currAmmo > 0){
            pa?.OnAttack();
            Attack();
        }
        }
    }
    protected virtual void Attack(){
        currCooldown = weaponData.CooldownDuration;
        currAmmo--;
    }
}
