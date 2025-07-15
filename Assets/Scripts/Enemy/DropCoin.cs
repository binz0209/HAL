using UnityEngine;

public class DropCoin : MonoBehaviour
{
    public GameObject coinPrefab;
    public int minDrop = 1;
    public int maxDrop = 3;

    public void DropCoins()
    {
        if (coinPrefab == null)
        {
            Debug.LogError("[DropCoin] ❌ coinPrefab is NOT assigned!");
            return;
        }

        int coinCount = Random.Range(minDrop, maxDrop + 1);

        for (int i = 0; i < coinCount; i++)
        {
            // Random offset: coin rơi tản ra quanh enemy
            Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(0.5f, 1.2f);
            Vector3 dropPos = transform.position + (Vector3)offset;
            dropPos.z = 0f;

            Instantiate(coinPrefab, dropPos, Quaternion.identity);
        }

        Debug.Log($"[DropCoin] ✅ Dropped {coinCount} coin(s) at random positions.");
    }
}
