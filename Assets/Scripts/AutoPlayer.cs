using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    
    // Speed of the AI
    public float speed = 2.7f;
    
    // the Ball
    Transform ball;
    
    // the ball's rigidbody 2D
    Rigidbody2D ballRig2D;

    public float topBound = 4.5f;

    public float bottomBound = -4.5f;
    void Start()
    {
       // Continuosly Invokes Move every x seconds (values may differ)
       InvokeRepeating("Move", .02f, .02f);
    }

    void Move()
    {
        // finding the ball
        if (ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball").transform;
        }
        
        //setting the ball's rigidbody to a variable
        ballRig2D = ball.GetComponent<Rigidbody2D>();

        if (ballRig2D.velocity.x > 0)
        {
            //checking y direction of ball
            if(ball.position.y < this.transform.position.y-.3F){
                //move ball down if lower than paddle
                transform.Translate(Vector3.down*speed*Time.deltaTime);
            } else if(ball.position.y > this.transform.position.y+.3F){
                //move ball up if higher than paddle
                transform.Translate(Vector3.up*speed*Time.deltaTime);
            }
        }
        //set bounds of AI
        if(transform.position.y > topBound){
            transform.position = new Vector3(transform.position.x, topBound, 0);
        } else if(transform.position.y < bottomBound){
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }

    }    
}
