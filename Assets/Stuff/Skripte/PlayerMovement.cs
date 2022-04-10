using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public float desiredSpeed =7f;
    public float jump = 3f;

    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;
    private float speed;
    private float targetTime=4f;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        speed = desiredSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(isGrounded && velocity.y<0){
            velocity.y = -2f;
        }

        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right*x+transform.forward*z;
        controller.Move(dir*speed*Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftShift)&&targetTime>0){
            speed=desiredSpeed+3f;
            targetTime-=Time.deltaTime;
        }
        else{
            speed = desiredSpeed;
            if(targetTime<4f)
                targetTime+=0.45f*Time.deltaTime;
        }

        
        


        if(Input.GetButtonDown("Jump")&&isGrounded){
            velocity.y = Mathf.Sqrt(jump*-2f*gravity);
        }
        



        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
