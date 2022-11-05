using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Transform _groundCheck; 
    [SerializeField]
    private float movementSpeed = 12f;
    [SerializeField]
    private float jumpHeight = 10f; 

    private Vector3 velocity;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private LayerMask groundMask; 
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private bool isGrounded; 

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0) { velocity.y = -2f; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movDirection = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Jump") && isGrounded) { velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); }

        _controller.Move(movDirection * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }
}
