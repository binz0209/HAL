using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator animator;



    [Header("Hitbox")]
    public Collider2D armCollider;

    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();

        if (animator == null)
            Debug.LogError("Animator not found!");

        if (armCollider != null)
            armCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            animator?.SetTrigger("2_Attack");
            isAttacking = true;
        }
    }

    // Called by animation event
    public void ActivateCollider()
    {
        if (armCollider != null)
            armCollider.enabled = true;
    }

    // Called by animation event
    public void DeactivateCollider()
    {
        if (armCollider != null)
            armCollider.enabled = false;

        isAttacking = false;
    }


}
