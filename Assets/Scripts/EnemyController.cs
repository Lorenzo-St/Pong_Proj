using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // speed of the enemy
    public float speed = 1.7f;
    
    // the ball
    private Transform ball;
    
    // the ball's rigidbody 2D
    private Rigidbody2D ballRig2D;
    
    // bounds of enemy
    public float topBound = 4.5f;
    public float bottomBound = -4.5f;
    
    // Use this for initialization
    void Start()
    {
        // Continuously Invokes Move every x seconds (values may differ)
        InvokeRepeating("Move", .02f, .02f);
    }

    void Move()
    {

        // Finding the ball
        if (ball == null)
        {
            ball = GameObject.FindWithTag("Ball").transform;
        }

        // setting the ball's rigidbody to a variable
        ballRig2D = ball.GetComponent<Rigidbody2D>();

        //checking x direction of the ball
        if (ballRig2D.velocity.x < 0)
        {
            //checking y direction
            if (ball.position.y < this.transform.position.y - .5f)
            {
                // moves ball down if lower 
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (ball.position.y > this.transform.position.y + .05f)
            {
                // moves ball up if higher that paddle
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x,bottomBound ,0);
        }
    }








    // Update is called once per frame
//    void FixedUpdate()
//    {
//        // finding the ball
//        ball = GameObject.FindGameObjectWithTag("Ball").transform;
//        
//        // setting the ball's rigidbody to a variable
//        ballRig2D = ball.GetComponent<Rigidbody2D>();
//        
//        // checking x direction of the ball
//        if (ballRig2D.velocity.x < 0)
//        {
//            // checking y direction of ball
//            if (ball.position.y < this.transform.position.y)
//            {
//                // move ball down if lower than paddle
//                transform.Translate(Vector3.down * speed * Time.deltaTime);
//            }else if (ball.position.y > this.transform.position.y)
//            {
//                // move ball up if higher than paddle
//                transform.Translate(Vector3.up * speed * Time.deltaTime);
//            }
//        }
//        
//        // set bounds of enemy


//}
}
