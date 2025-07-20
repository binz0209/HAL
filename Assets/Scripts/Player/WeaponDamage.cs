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
            if (SaveManager.Instance.currentData.selectedCharacter.Equals("XHum"))
            {
                enemyHealth.TakeDamage(60f + SaveManager.Instance.currentData.powerLevel * 5f);
            }
            else if (SaveManager.Instance.currentData.selectedCharacter.Equals("VanAn"))
            {
                enemyHealth.TakeDamage(100f + SaveManager.Instance.currentData.powerLevel * 5f);
            }
            else if (SaveManager.Instance.currentData.selectedCharacter.Equals("TuLinh"))
            {
                enemyHealth.TakeDamage(80f + SaveManager.Instance.currentData.powerLevel * 5f);
            }
        }

        if (enemyFollow != null)
        {
            Vector2 knockDir = (collision.transform.position - transform.position).normalized;
            enemyFollow.TakeDamageAndKnockback(knockDir, knockbackForce);
        }
    }
}
