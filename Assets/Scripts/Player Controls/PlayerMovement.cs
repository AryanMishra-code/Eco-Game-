using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public float footstepInterval = 1f;
    public float walkSpeed = 12f;
    public float runSpeed = 18f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    
    Vector3 _velocity;
    bool _isGrounded;

    private float currentSpeed = 0f;
    private float currentInterval;
    private float timer = 0f;
    private Vector2 input;
    
    void Update()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontal, vertical);

        if (input.sqrMagnitude > 0)
        {
            timer += Time.deltaTime;
            currentInterval = currentSpeed == runSpeed ? footstepInterval / 2 : footstepInterval;
            if (timer >= currentInterval && _isGrounded)
            {
                AudioManager.instance.Play(SoundName.Move_Ground);
                timer = 0f;
            }
        }

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        playerController.Move(direction * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;

        playerController.Move(_velocity * Time.deltaTime);
    }
}