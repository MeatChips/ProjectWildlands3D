using UnityEngine;

public class CamelPuzzle : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject walkColliderOne;
    [SerializeField] private GameObject walkColliderTwo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && !other.gameObject.name.Contains("SpaceShip"))
        {
            animator.SetTrigger("Bump");
            walkColliderOne.SetActive(true);
            walkColliderTwo.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
