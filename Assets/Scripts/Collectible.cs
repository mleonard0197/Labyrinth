using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject portalHere;
    //place on score collectables to play the sound and add to the score
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other) 
    {
        collectSound.Play();
        ScoreSystem.theScore += 50;
        if (this.gameObject.tag == "Key")
        {
            portalHere.gameObject.SetActive(true);
            Destroy(gameObject);
        }   
        else 
        {
            Destroy(gameObject);
        }
        
    }
}
