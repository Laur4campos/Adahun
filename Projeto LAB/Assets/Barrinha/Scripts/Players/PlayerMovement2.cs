using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpHeight;    

    //Character Controller
    private Rigidbody2D controller;
    Vector2 playerVelocity;
    Vector2 moveDirection;

    //GroundCheck
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    //Bool 
    bool isGrounded;
    public bool isRapel;

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    public void Move(Vector2 input)
    {
        if (!isRapel)
        {
            moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.y = input.y;
            //controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, 0);        
            playerVelocity.y += gravity * Time.deltaTime;
            //if (IsGrounded() && playerVelocity.y < 0)
            //    playerVelocity.y = -2f;
            if (IsGrounded())
                controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, playerVelocity.y * Time.deltaTime);
            controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, controller.velocity.y);
        }
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            if (!isRapel)
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        }
    }

    public void Rapel(Vector2 input)
    {
        if (isRapel)
        {
            //moveDirection = Vector3.zero;
            moveDirection.y = input.y;
            controller.velocity = new Vector2(controller.velocity.x, moveDirection.y * speed/2 * Time.deltaTime);
        }
    }

}
