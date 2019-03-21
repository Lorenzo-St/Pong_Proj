using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointCounter : MonoBehaviour
{
    public GameObject rightBound;
    public GameObject leftBound;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = rightBound.GetComponent<BoundController>().enemyScore + "\t\t" +
                    leftBound.GetComponent<BoundController>().playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = rightBound.GetComponent<BoundController>().enemyScore + "\t\t" +
                    leftBound.GetComponent<BoundController>().playerScore;
    }
}
