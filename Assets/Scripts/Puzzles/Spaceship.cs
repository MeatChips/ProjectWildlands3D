using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    public GameObject Rat;
    public Transform ratSpawnPoint;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GameObject spaceshipUi;
    
    //spaceship parts related
    private int _maxParts = 3;
    private int _collectedParts = 0;
    private bool _ratSpawned = false;

    void SpawnRat()//to indicate the rats spawn point
    {
        Debug.Log("Spawning rat at: " + ratSpawnPoint.position);
        Instantiate(Rat, ratSpawnPoint.position, ratSpawnPoint.rotation);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name.Contains("PickUpSpaceShip"))
    //    {
    //        Destroy(other.gameObject); //destroying the spaceship part
    //        _collectedParts++; //adding plus one on the collected parts
    //
    //        Debug.Log("Part successfully collected" + _collectedParts);
    //
    //        //spawning the rat after 2 spaceship parts are collected
    //        if (_collectedParts == 2 && !_ratSpawned)
    //        {
    //
    //            SpawnRat();
    //            _ratSpawned = true;
    //            Debug.Log("Find Larry the rat");
    //        }
    //
    //        //for going to the credits
    //        if (_collectedParts == _maxParts)
    //        {
    //            //switching to credit scene
    //            SceneManager.LoadScene("Comic Outro");
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("PickUpSpaceShip"))
        {

            Destroy(collision.gameObject); //destroying the spaceship part
            _collectedParts++; //adding plus one on the collected parts

            Debug.Log("Part successfully collected" + _collectedParts);

            confetti.Play();

            //spawning the rat after 2 spaceship parts are collected
            if (_collectedParts == 2 && !_ratSpawned)
            {

                SpawnRat();
                _ratSpawned = true;
                Debug.Log("Find Larry the rat");
                Destroy(spaceshipUi);
            }

            //for going to the credits
            if (_collectedParts == _maxParts)
            {
                //switching to credit scene
                SceneManager.LoadScene("Comic Outro");
            }
        }
    }
}