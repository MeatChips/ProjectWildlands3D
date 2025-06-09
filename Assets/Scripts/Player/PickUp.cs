using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float interactRange; // Range for player to interact with objects
    [SerializeField] private GameObject nearbyObject; // Nearby object
    [SerializeField] private GameObject heldObject; // Current held object
    [SerializeField] private Transform smallPlayerPickUpPos; // Position for pick up
    [SerializeField] private Transform bigPlayerPickUpPos; // Position for pick up
    [SerializeField] private float throwPower = 6f;
    private PlayerMovement playerMovement; // Player movement component
    private SphereCollider sphereCol; // Sphere collider / interact range
    [HideInInspector] public bool isBigPlayer = false;
    private Animator animator;
    [HideInInspector] public bool isAnimationGoingOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Grab player movement componenet
        sphereCol = GetComponent<SphereCollider>(); // Grab sphere collider
        sphereCol.radius = interactRange; // Set sphere collider radius
        animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If other has tag "PickUp", then set that gameobject as the nearbyObject
        if (other.CompareTag("PickUp"))
        {
            nearbyObject = other.gameObject;
        }
    }

    // Leaving 
    void OnTriggerExit(Collider other)
    {
        // If other gameobject is equal to the nearbyObject then set the nearbyObject to null
        if (other.gameObject == nearbyObject)
        {
            nearbyObject = null;
        }
    }

    public void GrabOrDrop(InputAction.CallbackContext context)
    {
        if (PauseSystem.Instance.isPaused)
            return;

        if (context.performed)
        {
            // If you hold no object and there is a object nearby
            if (heldObject == null && nearbyObject != null)
            {
                GrabObject(); // Grab object
            }
            else if (heldObject != null) // If you are holding a object
            {
                DropObject(); // Drop object
            }
        }
    }

    private void GrabObject()
    {
        // Start the coroutine
        StartCoroutine(WaitForAnimationAndGrab());
    }

    private IEnumerator WaitForAnimationAndGrab()
    {
        // Trigger the animation
        animator.SetTrigger("Interact");

        isAnimationGoingOn = true;

        // Wait one frame so the animator can update
        yield return null;

        // Wait until the "Interact" animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Interact"));

        // Wait until most of the animation is ended, in this case 80%
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .8f);

        // Grab The object
        heldObject = nearbyObject;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.GetComponent<SphereCollider>().enabled = false;

        // Attach the object to the correct position
        Transform chosenPickUpPos = isBigPlayer ? bigPlayerPickUpPos : smallPlayerPickUpPos;
        heldObject.transform.SetParent(chosenPickUpPos);
        heldObject.transform.position = chosenPickUpPos.position;

        isAnimationGoingOn = false;
    }

    // Drop object
    private void DropObject()
    {
        heldObject.transform.SetParent(null); // Remove parent
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Set isKinematic to false
        heldObject.GetComponent<SphereCollider>().enabled = true; // Set collider back
        if (!playerMovement.IsGrounded()) // If the player is not grounded
        {
            heldObject.GetComponent<Rigidbody>().AddForce(Vector3.up * throwPower, ForceMode.Impulse); // Add force up
            if (playerMovement.isMoving) // If the player is moving
                heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower, ForceMode.Impulse); // Add force up
        }
        heldObject = null; // No more heldObject


    }
}
