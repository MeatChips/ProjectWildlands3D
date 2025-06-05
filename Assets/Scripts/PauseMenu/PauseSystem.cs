using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    public Slider audioSlider;

    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }
}
