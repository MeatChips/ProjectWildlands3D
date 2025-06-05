using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string Credits)
    {
        SceneManager.LoadScene(Credits);
    }
}
