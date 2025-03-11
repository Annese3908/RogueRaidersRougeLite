using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rigidBody;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastX;
    [HideInInspector]    
    public float lastY;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed;
        moveDir = new Vector2(deltaX, deltaY);

        if (moveDir.x != 0){
            lastX = moveDir.x;
        }
        if (moveDir.y != 0){
             lastY = moveDir.y;
        }
    }
    private void Move(){
        rigidBody.velocity = moveDir;
    }
}
