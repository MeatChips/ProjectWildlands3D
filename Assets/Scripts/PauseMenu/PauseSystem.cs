using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;

    bool isPaused;
    public void PauseGame(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }
}
