using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator animator;
    public float knockbackForce = 10f;               // L?c knockback cho enemy khi player ?�nh
    public float knockbackFromEnemyForce = 10f;      // L?c knockback khi b? enemy ?�nh
    public float damageFromEnemy = 10f;              // S�t th??ng khi b? enemy ?�nh

    public Collider2D armCollider;

    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();

        if (animator == null)
            Debug.LogError("Animator kh�ng t�m th?y!");

        if (armCollider != null)
            armCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            if (animator != null)
                animator.SetTrigger("2_Attack");

            isAttacking = true;
        }

        if (Input.GetKeyUp(KeyCode.J) && isAttacking)
        {
            if (armCollider != null)
                armCollider.enabled = false;
        }
    }

    public void ActivateCollider()
    {
        if (armCollider != null && isAttacking)
            armCollider.enabled = true;
    }

    public void DeactivateCollider()
    {
        if (armCollider != null && isAttacking)
        {
            armCollider.enabled = false;
            isAttacking = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        Vector2 knockbackDirection = collision.transform.position - transform.position;
    //        EnemyFollow enemy = collision.GetComponent<EnemyFollow>();
    //        if (enemy != null)
    //            enemy.TakeDamageAndKnockback(knockbackDirection, knockbackForce);
    //    }
    //    else if (collision.CompareTag("Enemy_We"))
    //    {
    //        Vector2 knockbackDir = transform.position - collision.transform.position;

    //        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //        if (rb != null)
    //            rb.AddForce(knockbackDir.normalized * knockbackFromEnemyForce, ForceMode2D.Impulse);

    //        HealthManager healthManager = GetComponent<HealthManager>();
    //        if (healthManager != null)
    //            healthManager.TakeDamage(damageFromEnemy, knockbackDir, knockbackFromEnemyForce);
    //    }
    //}
}
