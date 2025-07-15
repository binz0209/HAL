using UnityEngine;
using TMPro;

public class CoinUIManager : MonoBehaviour
{
    public static CoinUIManager Instance;
    private int coin;

    public TextMeshProUGUI goldText;  // <- TextMeshPro

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LoadGold();
    }

    public void LoadGold()
    {
        if (SaveManager.Instance != null && SaveManager.Instance.currentData != null)
        {
            coin = SaveManager.Instance.currentData.gold;
            UpdateGoldDisplay(coin);
        }
    }

    public void UpdateGoldDisplay(int goldAmount)
    {
        if (goldText != null)
        {
            goldText.text = goldAmount.ToString();  // hoặc "x " + goldAmount
        }
    }
}
