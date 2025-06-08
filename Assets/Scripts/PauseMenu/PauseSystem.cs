using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem Instance { get; private set; }
    [SerializeField] private GameObject arrowIcon;
    [SerializeField] private GameObject pauseMenu = null;
    public Slider audioSlider;
    public bool isPaused;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed) // Check if the action was performed
        {
            IconChange arrowIcon = FindFirstObjectByType<IconChange>();
            if (arrowIcon != null) {
                arrowIcon.Deactivate();
            }
            Debug.Log("Pause button pressed"); // Log to console for debugging
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }
}
