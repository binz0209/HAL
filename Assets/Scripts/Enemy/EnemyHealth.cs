using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;

    private DropCoin coinSpawner;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coinSpawner = GetComponent<DropCoin>(); // lấy DropCoin script nếu có
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log($"[EnemyHealth] {gameObject.name} died.");

        // Gọi DropCoins nếu có
        if (coinSpawner != null)
        {
            Debug.Log("[EnemyHealth] Calling DropCoins...");
            coinSpawner.DropCoins();
        }
        else
        {
            Debug.LogWarning("[EnemyHealth] DropCoin component NOT found.");
        }

        if (animator != null)
        {
            animator.SetTrigger("4_Death");
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
            rb.simulated = false;
        }

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        EnemyTrigger.enemyCount--;

        Destroy(gameObject, 1f);
    }
}
