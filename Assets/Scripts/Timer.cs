using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                SceneLoader.LoadGameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Timer : MonoBehaviour
// {
//     public float timeCount;
//     public Text timeShow;

//     // Start is called before the first frame update
//     void Start()
//     {
//         timeCount = 0;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (timeCount > 0)
//         {
//             timeCount-= Time.deltaTime;
//             timeShow = "" + timeCount + "s";
//         }
//         else 
//         {
//             timeCount = 0;
//         }

//     }

//     void OnTriggerEnter(Collider other) 
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             timeCount = 60f;
//         }
//     }
// }
