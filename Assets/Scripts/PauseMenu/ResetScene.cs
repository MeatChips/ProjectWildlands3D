using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void ResetRequest()
    {
        string currentScene = SceneManager.GetActiveScene().name; // Get the current active scene
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
}