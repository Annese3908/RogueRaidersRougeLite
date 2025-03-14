using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerMovement pm;
    SpriteRenderer sr;
    Animator am;
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.moveDir.x !=0 || pm.moveDir.y != 0){
            am.SetBool("Move", true);
            SpriteDirection();
        }
        else{
            am.SetBool("Move", false);
        }
    }
    public void OnAttack()
    {
        am.SetBool("Attack", true);
        StartCoroutine(ResetAttackAfterDelay());
    }
    IEnumerator ResetAttackAfterDelay()
    {
        yield return new WaitForSeconds(0.4f); // Wait for the attack duration
        am.SetBool("Attack", false); // Reset the Attack parameter
    }

    void SpriteDirection()
    {
        if(pm.lastX > 0){
            sr.flipX = true;
        }
        else{
            sr.flipX = false;
        }
    }
}
