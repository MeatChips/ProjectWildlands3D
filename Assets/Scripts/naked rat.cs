using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; //for the coin collection code
using UnityEngine.UI;
using TMPro; //for using the UI of the game for the coin collector counter

[RequireComponent(typeof(Rigidbody))] // Attribute
public class Player : MonoBehaviour
{
    [SerializeField] // Attribute
    private Rigidbody rigidbody;
    private Vector2 input;
    [SerializeField] // Attribute
    private float speed = 5.0F;
    [SerializeField] // Attribute
    private TMP_Text score;
    // Update is called once per frame
    void Update()
    {
        // Changes the length (magnitude) of the vector to 1
        input.Normalize();

        var direction = new Vector3(input.x, 0, input.y) * speed;
        direction.y = rigidbody.linearVelocity.y;

        rigidbody.linearVelocity = direction;
    }
  



    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled) // Let go of WASD
            input = Vector2.zero;
        else // Otherwise, add movement!
            input += context.ReadValue<Vector2>();
    }
}
