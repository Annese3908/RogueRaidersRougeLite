using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class Definition for all weapons
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currCooldown;
    public int pierce;
    // Start is called before the first frame update
    void Start()
    {
        currCooldown = cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            Attack();
        }
    }
    void Attack(){
        currCooldown = cooldownDuration;
    }
}
