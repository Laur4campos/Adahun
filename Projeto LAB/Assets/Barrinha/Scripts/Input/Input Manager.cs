using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class InputManager : MonoBehaviour
{
    PlayerActions playerInput;
    PlayerActions.PlayerMapsActions playerActions;
    public PlayerMovement1 player1;
    public PlayerMovement2 player2;

    void Awake()
    {
        playerInput = new PlayerActions();
        playerActions = playerInput.PlayerMaps;        
             
        //Evento Pulo
        playerActions.Jump1.performed += ctx => player1.Jump();
        playerActions.Jump2.performed += ctx => player2.Jump();
    }
    private void FixedUpdate()
    {
        player1.Move(playerActions.Movement1.ReadValue<Vector2>());
        player2.Move(playerActions.Movement2.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        //look.Look(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
