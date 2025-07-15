using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
	public float damage = 100f;
	public float knockbackForce = 5f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
		EnemyFollow enemyFollow = collision.GetComponent<EnemyFollow>();

		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(damage);
		}

		if (enemyFollow != null)
		{
			Vector2 knockDir = (collision.transform.position - transform.position).normalized;
			enemyFollow.TakeDamageAndKnockback(knockDir, knockbackForce);
		}
	}
}
