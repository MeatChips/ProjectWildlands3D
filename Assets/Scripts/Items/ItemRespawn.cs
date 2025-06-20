using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    public enum KindOfPickUp
    {
        GrassBundle,
        SpaceshipPart,
        Boulder,
        Dog
    }

    public KindOfPickUp pickUpKind;

    private Vector3 originalPos;
    private Rigidbody rb;

    private void Awake()
    {
        originalPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
            transform.position = originalPos;
        }
    }
}
