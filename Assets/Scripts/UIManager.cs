using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    GameObject[] pauseObjects, finishObjects;
    
    // variables for bounds
    public BoundController rightBound;
    public BoundController leftBound;
    
    // game over variables
    public bool isFinished;
    public bool playerWon, enemyWon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");

        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        hideFinished();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevel == 1)
        {
            if (rightBound.enemyScore >= 7 && !isFinished)
            {
                isFinished = true;
                enemyWon = true;
                playerWon = false;
            } else if (leftBound.playerScore >= 7 && !isFinished)
            {
                isFinished = true;
                enemyWon = false;
                playerWon = true;
            }

            if (isFinished)
            {
                showFinish();
            }
        }

        // uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P) && !isFinished)
        {
            PauseControl();
        }

        if (Time.timeScale == 0 && !isFinished)
        {
            //searches through pauseObjects for PauseText
            foreach (GameObject g in pauseObjects)
            {
                if (g.name == "PauseText")
                {
                    g.SetActive(true);
                }
            }
        }
        else
        {
            foreach (GameObject g in pauseObjects)
            {
                if (g.name == "pauseObjects")
                {
                    g.SetActive(false);
                }
            }
        }
    }

    // Reloads the level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    // Controls the pausing of the scene
    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            
            showPaused();
        } else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

            hidePaused();
        }
    }
    
    // shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    
    // hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    // shows objects with ShowOnfinish tag
    public void showFinish()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    // Loads inputted level
    public void Loadlevel(string level)
    {
        Application.LoadLevel(level);
        Time.timeScale = 1;
    }
}

