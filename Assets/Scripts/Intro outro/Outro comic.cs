using UnityEngine;
using UnityEngine.SceneManagement;

public class Outrocomic : MonoBehaviour
{
    public void OnOutroComplete()
    {
        SceneManager.LoadScene("Credits"); // after outro go to the credits
    }
}