using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    public Transform enemy;

    public int enemyScore;

    public int playerScore;

    void start()
    {
        enemyScore = 0;

        playerScore = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                enemyScore++;
            }
            else
            {
                playerScore++;
            }
            //Destroys gameobject if its tag is ball
            Destroy(other.gameObject);

            // sets enemy's position back to origional
            enemy.position = new Vector3(-6, 0, 0);

            // pauses the game
            Time.timeScale = 0;
        }
    }
}
