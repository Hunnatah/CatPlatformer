using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public CharacterController controller;
    // variables for movespeed/jump power
    public float movementSpeed;
    public float dashPower;
    public float jumpPower;
    public float gravity;

    private bool isRunning;
    public bool doubleJump;

    private Vector2 moveDirection;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
        // Limits FPS to 60, allows running of program in backgrond
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        // Get the character controller and save it as "controller" for reference
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        moveDirection.x = 0;

        catMovement();
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void catMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
            isRunning = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
            isRunning = true;
        }

        else
        {
            isRunning = false;
        }

        if (isRunning == true)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", true);
        }

        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveDirection.x = moveDirection.x * dashPower;
        }
        // Multiply horizontal movement by speed, fix it to time 
        moveDirection.x = moveDirection.x * movementSpeed;

        // Apply gravity to our vertical movement
        moveDirection.y -= gravity * Time.deltaTime;

        if (controller.isGrounded && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = true;
        }

        // Checks if controller, then if true, controller may jump + gravity will be clamped
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controller.isGrounded || doubleJump)
            {
                moveDirection.y = Mathf.Clamp(moveDirection.y, -0.1f, float.PositiveInfinity);
                moveDirection.y = jumpPower;

                anim.SetBool("Jump", true);
            }
            if (doubleJump && (Input.GetKeyDown(KeyCode.Space)) && !controller.isGrounded)
            {
                moveDirection.y = Mathf.Clamp(moveDirection.y, -0.1f, float.PositiveInfinity);
                moveDirection.y = jumpPower;
                doubleJump = false;
                Debug.Log("Double Jump");
            }
        }
    }
}
