using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool canBeCollected = false;
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Bật lại sau 2s
        Invoke(nameof(EnableCollect), 2f);
    }

    private void EnableCollect()
    {
        canBeCollected = true;
        if (col != null)
        {
            col.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBeCollected) return;

        if (other.CompareTag("Player"))
        {
            if (SaveManager.Instance != null && SaveManager.Instance.currentData != null)
            {
                SaveManager.Instance.currentData.gold += 1;
                SaveManager.Instance.Save();

                // Gọi cập nhật UI
                if (CoinUIManager.Instance != null)
                {
                    CoinUIManager.Instance.UpdateGoldDisplay(SaveManager.Instance.currentData.gold);
                }
            }
            Destroy(gameObject);
        }
    }
}
