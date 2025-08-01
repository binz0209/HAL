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
    private float health;
    private float power;
    void Start()
    {
        // Retrieve the saved player data
        playerData = SaveManager.Instance.currentData;

        // Update UI elements on start
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (SaveManager.Instance.currentData.selectedCharacter.Equals("XHum"))
        {
            health = 250f + SaveManager.Instance.currentData.healthLevel * 10f;
            power = 60f + SaveManager.Instance.currentData.powerLevel * 5f;
        }
        else if (SaveManager.Instance.currentData.selectedCharacter.Equals("VanAn"))
        {
            health = 150f + SaveManager.Instance.currentData.healthLevel * 10f;
            power = 100f + SaveManager.Instance.currentData.powerLevel * 5f;
        }
        else if (SaveManager.Instance.currentData.selectedCharacter.Equals("TuLinh"))
        {
            health = 200f + SaveManager.Instance.currentData.healthLevel * 10f;
            power = 80f + SaveManager.Instance.currentData.powerLevel * 5f;
        }
        healthText.text = "HP: " + health.ToString();
        damageText.text = "DMG: " + power.ToString();
        coinText.text = playerData.gold.ToString();
        healthCost.text = (playerData.healthLevel * 5).ToString() + "G";
        damageCost.text = (playerData.powerLevel * 10).ToString() + "G";
    }
}
