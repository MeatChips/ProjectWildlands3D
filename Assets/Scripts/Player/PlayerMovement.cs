using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.0f; // Walk speed of the player
    [SerializeField] private float sneakSpeed = 2.5f; // Sneak speed of the player
    [SerializeField] private float rotationSpeed = 100.0f; // Rotation speed of the player
    [SerializeField] private float jumpHeight = 4.0f; // Jump height of the player

    [SerializeField] private LayerMask groundLayer; // Layer of ground
    [SerializeField] private Transform groundCheck; // Transform of ground check object

    [SerializeField] private CinemachineBrain cmBrain; // Cinemachine camera brain
    [SerializeField] private CinemachineCamera cmCam; // Cinemachine camera
    private ParticleSystem dustCloud; //particle system dust cloud

    private Rigidbody rb; // Rigidbody
    private Vector2 input; // Store player's input for movement (left, right / forward, backward)
    private PlayerInput playerInput; // Play input component
    private bool isSneaking = false; // Bool if you are sneaking
    private Animator animator; // Animator component
    
    public bool isMoving; // Check if the player is moving

   
       
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get rigidbody component
        playerInput = GetComponent<PlayerInput>(); // Grab playerinput component
        animator = GetComponentInChildren<Animator>(); // Grab the animator component of one of the children
        dustCloud = GetComponentInChildren<ParticleSystem>(); //grab the particlesystem component of one of the children
    }

    private void Start()
    {
        int playerID = playerInput.playerIndex; // Grab player ID
        OutputChannels channel = (OutputChannels)((int)OutputChannels.Channel01 << playerID);
        cmCam.OutputChannel = channel; // Set cinemachine camera output channel to the right channel
        cmBrain.ChannelMask = channel; // Set cinemachine brain channel mask to the right channel
    }

    void FixedUpdate()
    {


        // Changes the length of the vector to 1, so the same movement speed is same in every direction
        input.Normalize();

        // Create a movement direction vector
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // Check if the player has given enough input to move arond.
        if (moveDirection.magnitude >= 0.1f)
        {
            // Calculate the angle the player should rotate to.
            // Mathf.Atan2 calculates the angle (in radians) of the direction the player is moving-
            // Then we convert it to degrees so unity can use it for the rotation.
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            // Create a rotation for the player so they face the direction they are moving.
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

            // Rotate the player towards the target direction.
            // The player will rotate towards the target at a speed that is determined by the rotationSpeed and time between frames
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Set currentspeed depending if you are sneaking then use sneakSpeed, otherwise just use walkSpeed.
            float currentSpeed = isSneaking ? sneakSpeed : walkSpeed;

            // Now that the player is facing in the right direciton, move them in that direction.
            moveDirection = transform.forward * currentSpeed * Time.deltaTime;

            rb.MovePosition(rb.position + moveDirection); // Move the player

            isMoving = true; // The player is moving

            animator.SetBool("IsWalking", true);
            
            dustCloud.Play();


        }
        else
        {
            isMoving = false; // The player is not moving
            animator.SetBool("IsWalking", false);
            dustCloud.Stop(); //stops the particle effect
        }

         


    }

    // Function for player movement
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled) // Check if there is no input
            input = Vector2.zero; // No movement
        else // There is input
            input = context.ReadValue<Vector2>(); // Add movement
    }

    // Function for sneak
    public void Sneak()
    {
        if (PauseSystem.Instance.isPaused)
            return;

        // Set true or false
        isSneaking = !isSneaking;
    }

    // Function for player jumping
    public void Jump(InputAction.CallbackContext context)
    {
        if (PauseSystem.Instance.isPaused)
            return;

        // Check if the jump button is pressed and the player is grounded
        if (context.performed && IsGrounded())
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse); // Add force upward so the player jumps
    }

    // Boolean to check if the player is grounded
    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer); // Adjust layer mask as needed
    }

    
    
}
