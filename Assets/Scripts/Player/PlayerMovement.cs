using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f; // Movement speed of the player
    [SerializeField] private float rotationSpeed = 100.0f; // Rotation speed of the player
    [SerializeField] private float jumpHeight = 4.0f; // Jump height of the player

    private Rigidbody rb; // Rigidbody
    private Vector2 input; // Store player's input for movement (left, right / forward, backward)
    [SerializeField] private bool canJump; // Check if you can jump or not
    [SerializeField] private LayerMask groundLayer; // Layer of ground
    [SerializeField] private Transform groundCheck; // Transform of ground check object

    [SerializeField] private CinemachineBrain cmBrain; // Cinemachine camera brain
    [SerializeField] private CinemachineCamera cmCam; // Cinemachine camera

    private PlayerInput playerInput; // Play input component

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get rigidbody component

        playerInput = GetComponent<PlayerInput>(); // Grab playerinput component
    }

    private void Start()
    {
        int playerID = playerInput.playerIndex; // Grab player ID
        OutputChannels channel = (OutputChannels)((int)OutputChannels.Channel01 << playerID);
        cmCam.OutputChannel = channel; // Set cinemachine camera output channel to the right channel
        cmBrain.ChannelMask = channel; // Set cinemachine brain channel mask to the right channel
    }

    void Update()
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

            // Now that the player is facing in the right direciton, move them in that direction.
            moveDirection = transform.forward * movementSpeed * Time.deltaTime;

            rb.MovePosition(rb.position + moveDirection); // Move the player
        }

        // Check if the player is grounded and if you can jump again
        if (IsGrounded() && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse); // Add force upward so the player jumps
            canJump = false; // After jumping, set it the boolean to false. It goes back to true once you touch the ground again.
        }
    }

    // Function for player movement
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled) // Check if there is no input
            input = Vector2.zero; // No movement
        else // There is input
            input += context.ReadValue<Vector2>(); // Add movement
    }

    // Function for player jumping
    public void Jump(InputAction.CallbackContext context)
    {
        // Check if the jump button is pressed and the player is grounded
        if (context.performed && IsGrounded()) 
        {
            canJump = true; // You can jump again
        }
    }

    // Boolean to check if the player is grounded
    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, groundLayer))
        {
            // If the ray hits something within the distance, it's grounded
            return true;
        }
        return false;
    }
}
