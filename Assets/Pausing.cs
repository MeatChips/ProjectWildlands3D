using UnityEngine;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{
    public GameObject pauseCanvas; 
    public PauseSystem pauseSystem; // Reference to the PauseSystem script
    private void Awake()
    {
        pauseCanvas = GameObject.Find("Canvas"); // Find the PauseSystem script in the scene
        pauseSystem = pauseCanvas.GetComponent<PauseSystem>(); // Get the PauseSystem component from the canvas
    }
    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed) // Check if the action was performed
        {
            Debug.Log("Pause button pressed"); // Log to console for debugging
            pauseSystem.PauseToggle(); // Call the PauseToggle method from the PauseSystem script
        }
    }
}
