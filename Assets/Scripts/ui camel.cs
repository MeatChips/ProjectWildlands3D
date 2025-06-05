using UnityEngine;

public class UILocalTrigger : MonoBehaviour
{
    public GameObject uiCanvas; // Assign your UI canvas in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged")) // Or whatever your player tag is
        {
            uiCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            uiCanvas.SetActive(false);
        }
    }
}