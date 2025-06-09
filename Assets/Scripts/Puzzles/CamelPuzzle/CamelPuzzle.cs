using UnityEngine;

public class CamelPuzzle : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject walkColliderOne;
    [SerializeField] private GameObject walkColliderTwo;
    [SerializeField] private GameObject ChewParticle;
    [SerializeField] private GameObject uiCanvas;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemRespawn itemRespawn = other.GetComponent<ItemRespawn>();

        if (itemRespawn != null && itemRespawn.pickUpKind == ItemRespawn.KindOfPickUp.GrassBundle) // Remove or adjust based on enum use
        {
            animator.SetTrigger("Bump");
            walkColliderOne.SetActive(true);
            walkColliderTwo.SetActive(true);
            Destroy(other.gameObject);

            ChewParticle.SetActive(true); // Activate the chewing particle effect
            uiCanvas.gameObject.SetActive(false); // Hide the UI canvas
        }
    }
}
