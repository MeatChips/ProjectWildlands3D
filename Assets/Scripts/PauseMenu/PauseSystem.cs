using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    public Slider audioSlider;

    bool isPaused;

    public void PauseToggle()
    {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
    }
}
