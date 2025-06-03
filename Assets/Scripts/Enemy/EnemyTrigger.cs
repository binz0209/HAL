using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    public Transform enemyGroup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (enemyGroup == null)
        {
            Debug.LogWarning("No enemy group assigned!");
            return;
        }

        foreach (Transform child in enemyGroup)
        {
            EnemyFollow enemy = child.GetComponent<EnemyFollow>();
            if (enemy != null)
            {
                enemy.ActivateChase();
            }
        }

        Destroy(gameObject);
    }
}