using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is quitting...");
    }
}
