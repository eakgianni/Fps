using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public Transform groundCheck;

    Vector3 velocity;

    public float gravity = -9.81f;
    public float normalSpeed = 5f;
    public float speed;
    public float groundDistince = 0.4f;
    public float jumpHeight = 3f;
    public float dashSpeed = 10f;
    

    public LayerMask groundMask;

    public bool isGrounded;
    bool dashing = false;
    
    


    // Update is called once per frame
    void Update()
    {
       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistince, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            velocity.z = 0f;
            velocity.x = 0f;
        }

        if (isGrounded == true)
        {            
            float zd = Input.GetAxis("Vertical");// get the input
            float xd = Input.GetAxis("Horizontal");
            Vector3 move = transform.right * xd + transform.forward * zd; //put direction relative to layer into move                    
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);    
                velocity.x = transform.forward.x * zd * speed + transform.right.x * xd * speed;// adds x and z forces to the velocity based on wasd move ments idk why it works
                velocity.z = transform.forward.z * zd * speed + transform.right.z * xd * speed;                
            }
            
            if (Input.GetButtonDown("Fire3"))
            {
               Debug.Log(dashing); 
                
                if (dashing == true)
                {                    
                    
                    speed = normalSpeed;
                    dashing = false;
                }
                
                else if (dashing == false)
                {                  
                   
                    speed = dashSpeed;  
                    dashing = true;
				}
                   
			}
            
            if (move.x == 0f && move.z == 0f) // stops dash if player stops
            {
                
                speed = normalSpeed;
                dashing = false;       
			}
            controller.Move(move * speed * Time.deltaTime);          
       
        }
               
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);//gravity
        
        
        //if Input.GetAxis("Vertical" | "Horizontal")
        //{
      //head bob animation
      
		//}

    }


}
