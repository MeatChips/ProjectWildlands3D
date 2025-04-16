using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("SpaceShip"))
        {
            Destroy(other.gameObject);
        }
    }
}
