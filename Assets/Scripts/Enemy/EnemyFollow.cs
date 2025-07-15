using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    [Header("Movement")]
    public float speed = 0.5f;

    private bool isActive = false;

    [Header("Knockback")]
    private bool isKnockedBack = false;
    public float knockbackDuration = 0.2f; // Duration of knockback
    public float knockbackForce = 5f;      // Knockback force
    private Vector2 knockbackDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }
    public void ActivateChase()
    {
        isActive = true;
    }


    public void TakeDamageAndKnockback(Vector2 direction, float force)
    {
        if (isKnockedBack) return;

        knockbackDirection = direction.normalized;
        knockbackForce = force;
        isKnockedBack = true;

        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        StartCoroutine(RecoverFromKnockback());
    }

    void FixedUpdate()
    {
        if (isKnockedBack) return; // If knocked back, skip chasing

        if (!isActive || target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        // Flip sprite based on movement direction
        if (direction.x > 0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x < -0.1f)
            transform.localScale = new Vector3(1, 1, 1);
    }


    private IEnumerator RecoverFromKnockback()
    {
        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack = false;
    }

    // Detect collision with Sword to apply knockback.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            Vector2 dir = (transform.position - other.transform.position).normalized;
            TakeDamageAndKnockback(dir, knockbackForce);
        }
    }
}
