using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<PlayerMovement>(); // assumes this exists
    }

    void Update()
    {
        
    }
}
