using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public int speed;
    public int jumpForce;

    private float speedMultiplier = 1;

    private Rigidbody2D rb;
    private bool canIJump;


    void Start(){

        rb = GetComponent<Rigidbody2D>();
        speedMultiplier = 1;

    }

    void Update(){

        float HorizontalMovement = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2();
        movement.x = HorizontalMovement * (speed * speedMultiplier);
        movement.y = rb.velocity.y;
        rb.velocity = movement;

    }

    private void FixedUpdate(){
        
        float jumpAxis = Input.GetAxisRaw("Jump");

        if (jumpAxis != 0 && rb.velocity.y <= 0.05f){

            if (canIJump == true){

                canIJump = false;
                Jump(jumpAxis * (jumpForce * 10000) * Time.deltaTime);

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.tag == "Platform"){

            canIJump = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision){

        if (collision.gameObject.tag == "Platform"){

            canIJump = false;

        }

    }

    void Jump(float force){

        if (force < 0){

            return;

        }

        rb.AddForce(new Vector2(0, force));

    }

}
