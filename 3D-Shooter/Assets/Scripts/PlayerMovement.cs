using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed;
    private float walkSpeed = 10.0f;
    private float sprintSpeed = 20.0f;
    private float jumpStrength = 2.0f;
    private float gravity = -9.81f * 2;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;
    private float groundDistance = 0.4f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        // Input
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        // Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpStrength * -2 * gravity);
        }

        // Sprint
        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;

        }
        else
        {
            speed = walkSpeed;
        }

        // Crouch
        if (isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.5f;
        }
        else
        {
            controller.height = 2.1f;
        }

        // Forward Movement
        Vector3 move = transform.right * xInput + transform.forward * yInput;
        controller.Move(move * speed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

       

        
    }
}
