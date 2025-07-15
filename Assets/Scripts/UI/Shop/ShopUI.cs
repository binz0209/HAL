using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    // References to the TMP UI elements in the scene
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text coinText;
    public TMP_Text healthCost;
    public TMP_Text damageCost;

    // References to the player's data (could be fetched from SaveManager or PlayerCharacterData)
    private SaveData playerData;

    void Start()
    {
        // Retrieve the saved player data
        playerData = SaveManager.Instance.currentData;

        // Update UI elements on start
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = "HP: " + playerData.healthLevel.ToString();
        damageText.text = "DMG: " + playerData.powerLevel.ToString();
        coinText.text = playerData.gold.ToString();
        healthCost.text = (((playerData.healthLevel - 100) / 10)*2 + 5).ToString() + "G";
        damageCost.text = (((playerData.powerLevel - 5) / 5)*4 + 10).ToString() + "G";
    }
}
