using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
	public Image Health;
	public float healthAmount = 100f;
	public float damageOnCollision = 10f;

	void Update()
	{
		if (healthAmount <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void TakeDamage(float damage, Vector2 knockbackDir, float knockbackForce = 10f)
	{
		healthAmount -= damage;
		healthAmount = Mathf.Clamp(healthAmount, 0, 100);
		if (Health != null)
			Health.fillAmount = healthAmount / 100f;
    AudioManager.Instance?.PlayDamaged();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy_We"))
		{
			Vector2 knockbackDir = transform.position - collision.transform.position;
			TakeDamage(damageOnCollision, knockbackDir);
		}
	}
}
