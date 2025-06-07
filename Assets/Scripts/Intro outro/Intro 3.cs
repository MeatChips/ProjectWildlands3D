using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro3 : MonoBehaviour
{

    public void OnOutroComplete()
    {
        SceneManager.LoadScene("NEW TERRAIN"); // after second intro panel go to level
    }
}
