using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    //spaceship parts related
    private int _maxParts = 3;
    private int _collectedParts = 0;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("SpaceShip"))
        {
            Destroy(other.gameObject); //destroying the spaceship part
            _collectedParts++; //adding plus one on the collected parts

            Debug.Log("Part successfully collected" + _collectedParts);

            if ( _collectedParts >+_maxParts)
            {
                //switching to credit scene
                SceneManager.LoadScene("Credit Scene");
            }
        }
    }
}
