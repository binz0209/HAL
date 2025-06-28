using UnityEngine;

public class Player_Combat : MonoBehaviour
{
	private Animator animator;

	[Header("Combat")]
	public float damage = 100f;
	public float knockbackForce = 10f; // Knockback force to enemy

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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isAttacking) return;

		EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
		EnemyFollow enemyFollow = collision.GetComponent<EnemyFollow>();

		if (enemyHealth != null && enemyFollow != null)
		{
			enemyHealth.TakeDamage(damage);

			Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
			enemyFollow.TakeDamageAndKnockback(knockbackDirection, knockbackForce);
		}
	}
}
