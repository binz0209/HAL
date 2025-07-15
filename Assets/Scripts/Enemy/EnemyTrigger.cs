using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform enemyGroup;

    [Header("Door Settings")]
    public Collider2D doorCollider;

    private Animator doorAnimator;
    private bool roomLocked = false;
    private bool doorOpened = false;

    public static int enemyCount;

    private void Start()
    {
        if (doorCollider != null)
        {
            doorAnimator = doorCollider.GetComponent<Animator>();
        }
    }

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

        // 🔒 Lock cửa vật lý
        if (doorCollider != null)
        {
            doorCollider.isTrigger = false;
            Debug.Log("Door locked (isTrigger = false)");

            // ▶️ Chạy animation mở cửa MỘT LẦN
            if (!doorOpened && doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
                Debug.Log("Door animation: Open triggered");
                doorOpened = true;
            }
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
            Debug.Log("Door collider re-enabled (isTrigger = true)");
        }
    }
}
