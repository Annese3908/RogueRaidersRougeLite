using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player playerData;
    float currMoveSpeed;
    Rigidbody2D rigidBody;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastX;
    [HideInInspector]    
    public float lastY;
    [HideInInspector]
    public Vector2 lastMovedVector;
    // Start is called before the first frame update

    void Awake(){
        currMoveSpeed = playerData.MoveSpeed;
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); //default to right movement
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
    void FixedUpdate(){
        Move();
    }

    void InputManagement(){
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        moveDir = new Vector2(deltaX, deltaY).normalized;

        if (moveDir.x != 0){
            lastX = moveDir.x;
            lastMovedVector = new Vector2(lastX, 0f); //last x position vector
        }
        if (moveDir.y != 0){
             lastY = moveDir.y;
             lastMovedVector = new Vector2(0f, lastY); // last y position vector
        }
        if(moveDir.x != 0 && moveDir.y != 0){
            
            lastMovedVector = new Vector2(lastX, lastY); // last combined position vector while moving
        }
    }
    private void Move(){

        rigidBody.velocity = new Vector2(moveDir.x * currMoveSpeed, moveDir.y * currMoveSpeed);
    }
}
