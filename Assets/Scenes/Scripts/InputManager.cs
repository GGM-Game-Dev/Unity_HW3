using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private Weapon weapon;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        weapon = GetComponent<Weapon>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.HideWeapon.performed += ctx => weapon.HideWeapon();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //tell the player motor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        //Check every frame if the sprint key is pressed
        if (onFoot.Sprint.IsPressed())
        {
            motor.Sprint();
        }
        else 
        {
            motor.StopSprint();
        }

        if (onFoot.Crouch.IsPressed())
        {
            motor.Crouch();
        }
        else 
        {
            motor.StopCrouch();
        }
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
