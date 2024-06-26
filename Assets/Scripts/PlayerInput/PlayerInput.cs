using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour,PlayerActions.IPlayerControlsActions 
{
    public bool IsAttacking;
    public Action OnJumpInput;
    public Action OnAttackLeftInput;
    public Action OnMovementInput;

    public Action OnDodgeInput;


    public Vector3 movementVector;
    public PlayerActions playerActions;


    private void Start()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerControls.SetCallbacks(this);

        playerActions.PlayerControls.Enable();
        //playerActions.PlayerControls.Fire.ReadValue<int>() += ;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        movementVector = value.ReadValue<Vector2>();

        if(movementVector != Vector3.zero)
        {
            OnMovementInput?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed == false) return; // Using for we want only input press action, not others like releasing

        OnJumpInput?.Invoke();
    }
    
    public void OnDodge(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnDodgeInput?.Invoke();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IsAttacking = true;
            OnAttackLeftInput?.Invoke();
        }
        if(context.canceled)
        {
            IsAttacking = false;
        }
    }
    
}
