using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    //Camera turn speed
    public float horizontalSpeed = 2.0f;
    //Character move speed
    public float speed = 6f;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


        velocity.y += (gravity * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);

        // if (direction.magnitude >= 0.1f)
        // {
        //     controller.Move(direction * speed * Time.deltaTime);
        // }
    }

}
