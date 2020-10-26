using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    //Animations
    public GameObject[] erikaList;

    //Camera turn speed
    public float horizontalSpeed = 2.0f;
    //Character move speed
    public float speed = 8f;
    //Gravity that interacts with jumping and falling
    public float gravity = -12f;
    //Jump height
    public float jumpHeight = 3f;
    Vector3 velocity;

    //character weight
    public float weightChar = -2f;

    //Jump Check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //knockback
    public float knockBackForce;
    public float knockBackTime;
    public float knockBackCounter;

    //Pause obj
    GameObject[] pauseObjs;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjs = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }    
            
        }

        if (knockBackCounter <= 0)
        {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


            if (isGrounded && velocity.y < 0) 
            {
                velocity.y = -2f;
            }

            //Inputs WASD
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //Moves slower if moving backwards
            if (vertical < 0) 
            {
                speed = 4f;
            }
            else 
            {
                speed = 6f;
            }

            //Character movement through translating what direction the character is moving in that frame in a single plane, XZ
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            controller.Move(move * speed * Time.deltaTime);

            //Turns the character along Y
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0,h,0);

            //Jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (!isGrounded)
            {
                erikaList[1].SetActive(false);
                erikaList[2].SetActive(false);
                erikaList[3].SetActive(false);
                erikaList[4].SetActive(false);
                erikaList[5].SetActive(false);
                //erikaList[6].SetActive(false);
                erikaList[0].SetActive(true);
            }
            else if (isGrounded && vertical > 0)
            {
                erikaList[0].SetActive(false);
                erikaList[2].SetActive(false);
                erikaList[3].SetActive(false);
                erikaList[4].SetActive(false);
                erikaList[5].SetActive(false);
               // erikaList[6].SetActive(false);
                erikaList[1].SetActive(true);
            }
            else if (isGrounded && vertical == 0)
            {
                erikaList[0].SetActive(false);
                erikaList[1].SetActive(false);
                erikaList[3].SetActive(false);
                erikaList[4].SetActive(false);
                erikaList[5].SetActive(false);
               // erikaList[6].SetActive(false);
                erikaList[2].SetActive(true);
            }
            else if (!isGrounded && vertical < 0)
            {
                erikaList[0].SetActive(false);
                erikaList[1].SetActive(false);
                erikaList[2].SetActive(false);
                erikaList[4].SetActive(false);
                erikaList[5].SetActive(false);
                //erikaList[6].SetActive(false);
                erikaList[3].SetActive(true);
            }
            else if (isGrounded && vertical < 0)
            {
                erikaList[0].SetActive(false);
                erikaList[1].SetActive(false);
                erikaList[2].SetActive(false);
                erikaList[4].SetActive(false);
                erikaList[3].SetActive(false);
                //erikaList[6].SetActive(false);
                erikaList[5].SetActive(true);
            }


            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        //gravity
        velocity.y += (gravity * Time.deltaTime);
    }

    public void Knockback() 
    {
        knockBackCounter = knockBackTime;

        Vector3 direction = new Vector3(0f,0f,-1f);

        controller.Move(direction * knockBackForce * Time.deltaTime); 
    }

    public void showPaused() 
    {
        foreach(GameObject g in pauseObjs) 
        {
                g.SetActive(true);
        }
    }

    public void hidePaused() 
    {
        foreach(GameObject g in pauseObjs) 
        {
                g.SetActive(false);
        }
    }
}
