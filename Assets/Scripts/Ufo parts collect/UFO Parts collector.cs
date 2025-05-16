using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOPartscollector : MonoBehaviour
{

    //spaceship part realted
    private int _maxParts = 5;
    private int _collectedParts = 0;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("spaceship part"))
        {
            Destroy(collision.gameObject); // Destroying the parts not the spaceship
            _collectedParts++;

            Debug.Log("Parts Collected: " + _collectedParts);

            if (_collectedParts >= _maxParts)
            {
                // switches to the credit scene
                SceneManager.LoadScene("Credit scene");
            }
        }


    }  
   
}
