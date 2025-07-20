using UnityEngine;
using TMPro;

public class CoinUIManager : MonoBehaviour
{
    public static CoinUIManager Instance;
    private int coin;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI levelText;

    private int coinValue = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        levelText.text = SaveManager.Instance.currentData.playerName + " - Level: " + SaveManager.Instance.currentData.currentMapLevel.ToString();
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

    //increse coin value
    public void IncreaseCoinValue()
    {
        coinValue += 1;
        UpdateGoldDisplay(SaveManager.Instance.currentData.gold + coinValue);
    }

    public int getCoinValue()
    {
        return coinValue;
    }
    public void UpdateGoldDisplay(int goldAmount)
    {
        if (goldText != null)
        {
            goldText.text = goldAmount.ToString();  // hoặc "x " + goldAmount
        }
    }
}
