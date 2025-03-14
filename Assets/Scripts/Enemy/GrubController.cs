using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubController : EnemyController
{
    SpriteRenderer sr;
    Animator am;
    EnemyMovement em;

    // Movement variables
    private Vector2 attackDirection; // Direction of movement during attack
    private float attackSpeedMultiplier = 5f; // Speed multiplier during attack
    private bool isAttacking;

    protected override void Start(){
        base.Start();
        em = GetComponent<EnemyMovement>();
        am = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update(); // Call base Update to handle cooldown logic
        if (currCooldown <= 0f){
            if (!isAttacking){
                StartAttack();
            } 
            if (isAttacking){
             MoveDuringAttack();
            }
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        am.SetBool("Attacking", true);

        // Store the current movement direction as the attack direction
        attackDirection = em.moveDir;
    }

    private void MoveDuringAttack()
    {
        // Move grub in attack direction
        transform.position += (Vector3)attackDirection * enemyData.MoveSpeed * attackSpeedMultiplier * Time.deltaTime;
    }

    protected override void Attack()
    {
        base.Attack();
        // Reset attack state after the attack is complete
        isAttacking = false;
        am.SetBool("Attacking", false);
    }
}