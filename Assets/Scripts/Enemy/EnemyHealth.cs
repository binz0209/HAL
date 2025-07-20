using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;

    private DropCoin coinSpawner;
    private static int totalEnemyCount = 12;

    // Flash effect
    public float flashDuration = 0.2f;
    private bool isFlashing = false;
    private float flashTimer = 0f;
    private SpriteRenderer[] spriteRenderers;
    private Color[] originalColors;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coinSpawner = GetComponent<DropCoin>();

        // Lưu lại các SpriteRenderer để đổi màu
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
        }
    }

    void Update()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;
            if (flashTimer <= flashDuration)
            {
                foreach (var sr in spriteRenderers)
                {
                    sr.color = Color.red;
                }
            }
            else
            {
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].color = originalColors[i];
                }
                isFlashing = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (!isFlashing)
        {
            isFlashing = true;
            flashTimer = 0f;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        // Use the public method to decrement totalEnemyCount  
        EnemyTrigger.ReportEnemyDied();

        if (coinSpawner != null)
        {
            coinSpawner.DropCoins();
        }

        if (animator != null)
        {
            animator.SetTrigger("4_Death");
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        EnemyTrigger.enemyCount--;

        StartCoroutine(HandleDeathCoroutine());
    }

    private IEnumerator HandleDeathCoroutine()
    {
        // Tắt toàn bộ script attack nếu có
        Enemy_Combat combat = GetComponentInChildren<Enemy_Combat>();
        if (combat != null)
            combat.enabled = false;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
