using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject love;

    void OnTriggerEnter(Collider other) // void used since this is for an action, triggerenter since since there is a collision between the player and prairie dog
    {
        if (other.CompareTag("Player")) // if player approaches the prairie dog the ui image appears
        {
            love.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) // action for when the player leaves the radius of the prairie 
    {
        if (other.CompareTag("Player")) // if player leaves the prairie dog area the ui image disappears 
        {
            love.SetActive(false);
        }
    }
}