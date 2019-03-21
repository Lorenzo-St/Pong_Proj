using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // speed of ball
    public float speed = 3.5f;
    
    // the initial direction of the ball
    private Vector2 spawnDir;
    
    // ball's components
    private Rigidbody2D rig2D;
    
    // Use this for initialization
    void Start()
    {
        // setting balls Rigidbody 2D
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        
        // generating random number based on possible initial directions
        int rand = Random.Range(1, 4);
        
        // setting initial direction
        if (rand == 1)
        {
            spawnDir = new Vector2(1,1);
        }else if (rand == 2)
        {
            spawnDir = new Vector2(1,-1);
        }else if (rand == 3)
        {
            spawnDir = new Vector2(-1,-1);
        }else if (rand == 4)
        {
            spawnDir = new Vector2(-1,1);
        }
        
        // moving ball in initial direction and adding speed
        rig2D.velocity = (spawnDir * speed);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        // tag check
        if (col.gameObject.tag == "Enemy")
        {
            //calculate angle
            float y = launchAngle(transform.position, col.transform.position, col.collider.bounds.size.y);            
            // Set angle and speed
            Vector2 d = new Vector2(1, y).normalized;

            rig2D.velocity = d * speed * 1.5f;
        }
        if (col.gameObject.tag == "Player")
        {
            //calculate angle
            float y = launchAngle(transform.position, col.transform.position, col.collider.bounds.size.y);            
            // Set angle and speed
            Vector2 d = new Vector2(-1, y).normalized;

            rig2D.velocity = d * speed * 1.5f;
        }
    }

    float launchAngle(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
