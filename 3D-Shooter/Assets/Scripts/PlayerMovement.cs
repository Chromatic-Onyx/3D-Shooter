using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody rb;
    float HorizontalInput;
    float VerticalInput;
    bool grounded;
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask ground;
    private float jumpStrength = 25f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        if (grounded && Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouch");
        }

    }
    private void FixedUpdate()
    {
        Vector3 move = HorizontalInput * transform.right +  VerticalInput * transform.forward;
        rb.MovePosition(transform.position + speed * move * Time.deltaTime);
    }



}
