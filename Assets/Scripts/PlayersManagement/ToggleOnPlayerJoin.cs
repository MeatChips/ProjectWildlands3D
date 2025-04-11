using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleOnPlayerJoin : MonoBehaviour
{
    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        // Grab the PlayerInputManager
        playerInputManager = FindAnyObjectByType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        // Subscribe to the event when a player joins
        playerInputManager.onPlayerJoined += ToggleThis;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when the object is disabled
        playerInputManager.onPlayerJoined -= ToggleThis;
    }

    // Turn off main camera
    private void ToggleThis(PlayerInput player)
    {
        // Deactivate the gameObject (camera)
        this.gameObject.SetActive(false);
    }
}
