using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charactercontroller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    private ObstaclePush op;
    private CharacterController controller;
    private Animator anim;
   

    private void Start()
    {
        op = GetComponent<ObstaclePush>();
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 move = transform.right * x;
        charactercontroller.Move(move * speed * Time.deltaTime);

     
        if (Input.GetKey(KeyCode.D) && isGrounded && op.CanPush == false)
        {
            walkingRight();
        }
        else if (Input.GetKey(KeyCode.D) && isGrounded && op.CanPush == true)
        {
          anim.SetBool("pushingRight", true);
        }

        else if (!Input.GetKey(KeyCode.D) && isGrounded)
        {
            anim.SetBool("walkingRight", false);
            anim.SetBool("pushingRight", false);

        }

        if (Input.GetKey(KeyCode.A) && isGrounded && op.CanPush == false)
        {
            walkingLeft();
        }
        else if (Input.GetKey(KeyCode.A) && isGrounded && op.CanPush == true)
        {
            anim.SetBool("pushingLeft", true);
        }

        else if (!Input.GetKey(KeyCode.A) && isGrounded)
        {
            anim.SetBool("walkingLeft", false);
            anim.SetBool("pushingLeft", false);

        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Jump();

        }
        else if((!Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {
            anim.SetBool("Jump", false);
        }

        velocity.y += gravity * Time.deltaTime;
        charactercontroller.Move(velocity * Time.deltaTime);
        


    }

    private void Idle()
    {
        anim.speed = 0;
        anim.SetBool("Jump", false);
        anim.SetBool("walkingRight", false);
        anim.SetBool("walkingLeft", false);
    }
    private void walkingLeft()
    {
        anim.SetBool("walkingLeft", true);
    }
    private void walkingRight()
    {
        anim.SetBool("walkingRight", true);
    }
    private void Jump()
    {
        anim.SetBool("Jump", true);

    }

}