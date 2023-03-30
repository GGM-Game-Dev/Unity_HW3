using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    enum PlayerMotorState 
    {
        walking,
        running,
        crouching,
        inAir
    }
    private PlayerMotorState motorState=PlayerMotorState.walking;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool IsGrounded;
    public float graviry = -9.8f;
    public float jumpHeight = 3f;
    private bool Sprinting = false;
    private bool isCrouching = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        if (!IsGrounded) 
        {
            motorState = PlayerMotorState.inAir;
        }
        else if (Sprinting) 
        {
            motorState = PlayerMotorState.running;
        }
        if (motorState == PlayerMotorState.crouching) 
        {
            Sprinting = false;
        }
    }
    

    //Recive the input for out InputManager.cs and apply them to out character controller
    public void ProcessMove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += graviry * Time.deltaTime;
        if (IsGrounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump() 
    {
        if (IsGrounded && !isCrouching) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * graviry);
        }
    }
    /**
     * Sptinting is not in crouch mode
     */
    public void Sprint() 
    {
        if (!isCrouching )
        {
            speed = 10f;
            Sprinting = true;
            motorState = PlayerMotorState.running;
        }
        else
        //Crouch -> cannot sprint
        {
            speed = 3f;
            motorState = PlayerMotorState.crouching;

        }
    }
    /**
     * Stop sprinting and move to walk state
     */
    public void StopSprint() 
    {
        if (!isCrouching)
        {
            speed = 5f;
            Sprinting = false;
            motorState= PlayerMotorState.walking;
        }
        else
        //Crouch -> cannot walk
        {
            speed = 3f;
            motorState = PlayerMotorState.crouching;
        }
    }
    public void Crouch() 
    {
        if (IsGrounded) 
        {
            isCrouching = true;
            Vector3 crouchSizeVector = new Vector3(1, 0.6f, 1);
            this.transform.localScale = crouchSizeVector;
            motorState = PlayerMotorState.crouching;

        }
    }
    public void StopCrouch() 
    {
        isCrouching=false;
        this.transform.localScale = Vector3.one;
        motorState = PlayerMotorState.walking;
    }

    
}
