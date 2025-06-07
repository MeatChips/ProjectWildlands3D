using UnityEngine;

public class CamelPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject camelBump;
    [SerializeField] private GameObject ChewParticle;
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private MonoBehaviour uiCamel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && !other.gameObject.name.Contains("SpaceShip"))
        {
            camelBump.transform.localScale += new Vector3(0, 0, 70);
            Destroy(other.gameObject);

            ChewParticle.SetActive(true); // Activate the chewing particle effect

            uiCamel.enabled = false; // Disable the UI camel script to prevent further interaction

            uiCanvas.SetActive(false); // Hide the UI canvas when the camel eats the object


        }
    }
}
