using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2 : MonoBehaviour
{
    public void OnOutroComplete()
    {
        SceneManager.LoadScene("Intro Comic 2"); // after intro scene 2 got to the level
    }
}