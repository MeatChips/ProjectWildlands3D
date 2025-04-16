using UnityEngine;

public class CamelPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject camelBump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            camelBump.transform.localScale += new Vector3(0, 0, 70);
            Destroy(other.gameObject);
        }
    }
}
