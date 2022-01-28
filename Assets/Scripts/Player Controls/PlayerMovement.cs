using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    
    public float moveSpeed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    
    Vector3 _velocity;
    bool _isGrounded;
    
    void Start()
    {
        
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        float xMovementInput = Input.GetAxis("Horizontal");
        float zMovementInput = Input.GetAxis("Vertical");

        Vector3 motion = transform.right * xMovementInput + transform.forward * zMovementInput;

        playerController.Move(motion * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;

        playerController.Move(_velocity * Time.deltaTime);
    }
}