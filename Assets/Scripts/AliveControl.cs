using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveControl : MonoBehaviour
{
    //place on score collectables to play the sound and add to the score
    public AudioSource hurtSound;
    //public Health livesC;
    public Rigidbody rb;

    public static bool invincible = false;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Death") 
            {
                Health.live = 0;
            }
            else
            {
                if(!invincible) 
                {
                    hurtSound.Play();
                    Health.live -= 1;
                    rb.AddForce(transform.forward * -20.0f);
                    FindObjectOfType<ThirdPersonMovement>().Knockback();
                    invincible = true;
                    Invoke("resetInvulnerability", 2);
                }
        
            }
        }   
        //Destroy(gameObject);
    }

    void resetInvulnerability()
    {
        invincible = false;
    }
}
