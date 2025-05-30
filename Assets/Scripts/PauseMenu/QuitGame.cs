using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitGameboyer()
    {
        Application.Quit();
        Debug.Log("Game is quitting...");
    }
}
