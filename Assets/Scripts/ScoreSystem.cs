using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    //controls display for score and stores/updates the score. place on random gameobject

    public GameObject scoreText;
    public static int theScore;

    void Start() 
    {
        theScore = 0;    
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "" + theScore;    
    }
}
