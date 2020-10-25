using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   //controls display for score and stores/updates the score. place on random gameobject
    public GameObject heart1, heart2, heart3;
    public static int live;
    public SceneLoader func;

    void Start() 
    {
        live = 3;
        heart1.gameObject.SetActive (true);
        heart2.gameObject.SetActive (true);
        heart3.gameObject.SetActive (true);
    }

    void Update()
    {
        if (live > 3)
            live = 3;
        
        switch (live)
        {
            case 3:
                heart1.gameObject.SetActive (true);
                heart2.gameObject.SetActive (true);
                heart3.gameObject.SetActive (true);
                break;
            case 2:
                heart1.gameObject.SetActive (false);
                break;
            case 1:
                heart2.gameObject.SetActive (false);
                break;
            case 0:
                heart1.gameObject.SetActive (false);
                heart2.gameObject.SetActive (false);
                heart3.gameObject.SetActive (false);
                func.ReloadScene();
                break;
        }  
    }
}
