using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    // References to the TMP UI elements in the scene
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text coinText;

    // References to the player's data (could be fetched from SaveManager or PlayerCharacterData)
    private SaveData playerData;

    void Start()
    {
        // Retrieve the saved player data
        playerData = SaveManager.Instance.currentData;

        // Update UI elements on start
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update the health, damage, and coin values based on the player's data
        healthText.text = "HP: " + playerData.healthLevel.ToString();
        damageText.text = "DMG: " + playerData.powerLevel.ToString(); // Assuming powerLevel is damage
        coinText.text = playerData.gold.ToString();
    }
}
