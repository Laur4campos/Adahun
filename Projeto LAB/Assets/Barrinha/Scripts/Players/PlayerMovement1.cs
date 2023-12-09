using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerMovement1 : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float speed, rapelSpeed;
    [SerializeField] float gravity = -98f;
    [SerializeField] float jumpHeight;

    //Character Controller    
    private Rigidbody2D controller;
    [Header("Character Controller")]
    [SerializeField] Vector2 playerVelocity;
    [SerializeField] Vector2 moveDirection;

    //GroundCheck
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    //Bool 
    bool isGrounded;
    public bool isRapel;

    //Enum Players
    enum playerName { Jogador1, Jogador2 };
    [SerializeField] playerName i;

    //PlayerActions
    PlayerActions playerInput;
    

    [Header("GameManager")]
    [SerializeField] GM gm;

    void Awake()
    {
        playerInput = new PlayerActions();
        switch (i)
        {
            case playerName.Jogador1:
                playerInput.PlayerMaps.Jump1.performed += ctx => Jump();
                break;
            
            case playerName.Jogador2:
                if (gm.mode == GM.playerMode.MULTI)
                {
                    playerInput.PlayerMaps.Jump2.performed += ctx => Jump();
                }
                else
                {
                    playerInput.PlayerMaps.Jump1.performed += ctx => Jump();
                }
                break;

        }

    }

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();        
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    public void FixedUpdate()
    {
        switch (i)
        {
            case playerName.Jogador1:
                //playeraction                    
                //if(!single && !playerSelected == pl2)
                    MoveController(playerInput.PlayerMaps.Movement1.ReadValue<Vector2>());
                    Rapel(playerInput.PlayerMaps.Movement1.ReadValue<Vector2>());                
                break;

            case playerName.Jogador2:
                if (gm.mode == GM.playerMode.MULTI)
                {
                    MoveController(playerInput.PlayerMaps.Movement2.ReadValue<Vector2>());
                    Rapel(playerInput.PlayerMaps.Movement2.ReadValue<Vector2>());
                }
                else
                {
                    MoveController(playerInput.PlayerMaps.Movement1.ReadValue<Vector2>());
                    Rapel(playerInput.PlayerMaps.Movement1.ReadValue<Vector2>());
                }
                break;

            default: break;

        }
        
    }

    void MoveController(Vector2 input)
    {
        if (!isRapel)
        {
            moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.y = input.y;
            //controller.velocity = new Vector2(moveDirection.x * speed * Time.deltaTime, 0);        
            playerVelocity.y += gravity * Time.deltaTime;

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
            //playerVelocity.y += gravity * Time.deltaTime;
            moveDirection.x = input.x;
            controller.velocity = new Vector2(moveDirection.x * rapelSpeed / 2 * Time.deltaTime, controller.velocity.y);
        }
    }

    public Vector2 GetPosition()
    {
        return this.controller.position;
    }
    private void OnEnable()
    {
        playerInput.PlayerMaps.Enable();
    }

    private void OnDisable()
    {
        playerInput.PlayerMaps.Disable();
    }


}
