using TMPro;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI statText;
    private SaveData playerData;
    private float health;
    private float power;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData = SaveManager.Instance.currentData;
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
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
        playerNameText.text = "Gud Game " + playerData.playerName;
        statText.text = "Level: " + playerData.currentMapLevel +
                        "\nHP: " + health.ToString() +
                        "\nDMG: " + power.ToString() +
                        "\nGold: " + playerData.gold.ToString();
    }
}
