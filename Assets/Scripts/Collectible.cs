using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //place on score collectables to play the sound and add to the score
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other) 
    {
        collectSound.Play();
        ScoreSystem.theScore += 50;   
        Destroy(gameObject);
    }
}
