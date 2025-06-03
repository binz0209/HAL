using UnityEngine;

public class DevilTrigger : MonoBehaviour
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
            DevilMove devil = child.GetComponent<DevilMove>();
            if (devil != null)
            {
                devil.ActivateChase();
            }
        }

        Destroy(gameObject); 
    }
}
