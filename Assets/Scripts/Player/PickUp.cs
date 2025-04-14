using Unity.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float interactRange; // Range for player to interact with objects
    [SerializeField] private GameObject nearbyObject; // Nearby object
    [SerializeField] private GameObject heldObject; // Current held object
    [SerializeField] private Transform PickUpPos; // Position for pick up
    
    private SphereCollider sphereCol; // Sphere collider / interact range

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereCol = GetComponent<SphereCollider>(); // Grab sphere collider
        sphereCol.radius = interactRange; // Set sphere collider radius
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

    public void GrabOrDrop()
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

    // Grab object
    private void GrabObject()
    {
        heldObject = nearbyObject; // Set heldObject to the object of nearbyObject
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // Set isKinematic to true
        heldObject.transform.SetParent(PickUpPos); // Set parent
        heldObject.transform.position = PickUpPos.transform.position; // Set position
    }

    // Drop object
    private void DropObject()
    {
        heldObject.transform.SetParent(null); // Remove parent
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Set isKinematic to false
        heldObject = null; // No more heldObject
    }

}
