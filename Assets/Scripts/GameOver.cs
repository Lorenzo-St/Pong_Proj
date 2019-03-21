using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public UIManager uiManager;

    private Text text;
    
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.playerWon)
        {
            text.text = "GAME OVER! \nPLAYER WON!";
        } else if (uiManager.enemyWon)
        {
            text.text = "GAME OVER! \nENEMY Won!";
        }
    }
}
