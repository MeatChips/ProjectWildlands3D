using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public void OnCreditsComplete()
    {
        SceneManager.LoadScene("Main Menu"); // after credits are done return to the main menu screen
    }
}