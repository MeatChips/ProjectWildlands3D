using UnityEngine;

public class CamelPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject camelBump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && !other.gameObject.name.Contains("SpaceShip"))
        {
            camelBump.transform.localScale += new Vector3(0, 0, 70);
            Destroy(other.gameObject);
        }
    }
}
