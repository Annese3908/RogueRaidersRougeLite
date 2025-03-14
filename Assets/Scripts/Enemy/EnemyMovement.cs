using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemyData;
    Transform player;
    SpriteRenderer sr;
    PlayerMovement pm;
    [HideInInspector]
    public Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        sr = GetComponent<SpriteRenderer>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        moveDir = new Vector2(transform.position.x, transform.position.y);
        if(pm.lastX >= 0){
            sr.flipX = true;
        }else{
            sr.flipX = false;
        }
    }
    
}
