using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyTrigger : MonoBehaviour
{
    [Header("Teleport Settings")]
    public GameObject teleportObject;

    [Header("Enemy Settings")]
    public Transform enemyGroup;

    [Header("Door Settings")]
    public Collider2D doorCollider;

    private Animator doorAnimator;
    private bool roomLocked = false;
    private bool doorOpened = false;
    private bool teleportSpawned = false;

    public static int enemyCount;
    private Collider2D teleportCollider;
    private static int totalEnemyCount = 0;
    private void Start()
    {
        if (doorCollider != null)
        {
            doorAnimator = doorCollider.GetComponent<Animator>();
        }

        if (teleportObject != null)
        {
            teleportObject.SetActive(false);
            teleportCollider = teleportObject.GetComponent<Collider2D>();
            if (teleportCollider != null)
            {
                teleportCollider.enabled = false;
            }
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

        if (doorCollider != null)
        {
            doorCollider.isTrigger = false;

            if (!doorOpened && doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
                doorOpened = true;
            }
        }

        roomLocked = true;
    }

    private void Update()
    {
        if (!roomLocked || teleportSpawned) return;

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
        totalEnemyCount--;
        Debug.Log("Total Enemy Count Set: " + totalEnemyCount);
    }

    void UnlockRoom()
    {
        roomLocked = false;

        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
        }

        if (SaveManager.Instance.currentData.currentMapLevel == 2 && (totalEnemyCount % 12) == 0)
        {
            // Change to Victory Scene
            SaveManager.Instance.currentData.gold += CoinUIManager.Instance.getCoinValue();
            SaveManager.Instance.Save();
            SceneManager.LoadScene(8);
        }

        if (teleportObject != null && (totalEnemyCount % 12) == 0)
        {
            teleportSpawned = true;
            StartCoroutine(FadeInTeleport());
        }

    }

    IEnumerator FadeInTeleport()
    {
        SpriteRenderer sr = teleportObject.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogWarning("Teleport object lacks SpriteRenderer!");
            yield break;
        }

        teleportObject.SetActive(true);

        Color color = sr.color;
        color.a = 0f;
        sr.color = color;

        float duration = 1.5f;
        float timer = 0f;

        while (timer < duration)
        {
            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            sr.color = color;
            timer += Time.deltaTime;
            yield return null;
        }

        color.a = 1f;
        sr.color = color;

        yield return new WaitForSeconds(2f);
        if (teleportCollider != null)
        {
            teleportCollider.enabled = true;
        }
    }

}