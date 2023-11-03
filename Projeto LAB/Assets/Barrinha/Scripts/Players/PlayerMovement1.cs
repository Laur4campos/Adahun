using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpHeight;
    bool isGrounded;

    //Character Controller
    private Rigidbody2D controller;
    Vector2 playerVelocity;

    //GroundCheck
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
   

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // isGrounded = controller.isGrounded;
    }

    private bool IsGrounded()
    {    
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    public void Move(Vector2 input)
    {
        Vector2 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.y = input.y;
        //controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, 0);        
        playerVelocity.y += gravity * Time.deltaTime;
        if (IsGrounded() && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, playerVelocity.y * Time.deltaTime);

    }
    public void Jump()
    {
        if (IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        }
    }

}
