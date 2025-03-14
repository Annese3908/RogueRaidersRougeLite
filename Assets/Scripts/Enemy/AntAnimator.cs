using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAnimator : MonoBehaviour
{
    Animator am;
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
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

}
