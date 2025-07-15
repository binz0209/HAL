using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform enemyGroup;

    [Header("Door Settings")]
    public Collider2D doorCollider;

    private bool roomLocked = false;

    public static int enemyCount;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player triggered EnemyTrigger!");

        if (enemyGroup == null)
        {
            Debug.LogWarning("No enemy group assigned!");
            return;
        }

        enemyCount = 0;

        foreach (Transform child in enemyGroup)
        {
            EnemyFollow enemy = child.GetComponent<EnemyFollow>();
            if (enemy != null)
            {
                enemy.ActivateChase();
                enemyCount++;
            }
        }

        Debug.Log("Enemy Count: " + enemyCount);


        if (doorCollider != null)
        {
            doorCollider.isTrigger = false;
            Debug.Log("Door locked (isTrigger = false)");
        }

        roomLocked = true;


    }

    private void Update()
    {
        if (!roomLocked) return;

        if (AllEnemiesDefeated())
        {
            UnlockRoom();
        }
    }

    bool AllEnemiesDefeated()
    {
        foreach (Transform child in enemyGroup)
        {
            if (child != null)
                return false;
        }
        return true;
    }

    public static void ReportEnemyDied()
    {
        enemyCount--;
        Debug.Log("Enemy died. Remaining: " + enemyCount);
    }

    void UnlockRoom()
    {
        Debug.Log("UnlockRoom() called");
        roomLocked = false;

        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
            Debug.Log("Door unlocked (isTrigger = true)");
        }


    }
}
