using UnityEngine;

public class uicamel : MonoBehaviour
{
    public GameObject uiCanvas; 

    void OnTriggerEnter(Collider other) // void used since this is for an action, triggerenter since since there is a collision between the player and camel
    {
        if (other.CompareTag("Untagged")) // if player approaches the camel the ui image appears
        {
            uiCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) // action for when the player leaves the radius of the camel 
    {
        if (other.CompareTag("Untagged")) // if player leaves the camel area the ui image disappears 
        {
            uiCanvas.SetActive(false);
        }
    }
}