using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2 : MonoBehaviour
{
    public void OnOutroComplete()
    {
        SceneManager.LoadScene("NEW TERRAIN"); // after intro scene 2 got to the level
    }
}