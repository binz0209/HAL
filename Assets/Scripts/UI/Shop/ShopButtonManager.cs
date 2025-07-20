using UnityEngine;

public class ShopButtonManager : MonoBehaviour
{
    public ShopUI shopUI;
    // Buy health button
    public void BuyHealth()
    {
        int healthCost = SaveManager.Instance.currentData.healthLevel * 5;
        if (SaveManager.Instance.currentData.gold >= healthCost)
        {
            SaveManager.Instance.currentData.gold -= healthCost;
            SaveManager.Instance.currentData.healthLevel += 1;
            SaveManager.Instance.Save();
            //Shopui update
            shopUI.UpdateUI();
        }
    }

    // Buy damage button
    public void BuyDamage()
    {
        int damageCost = SaveManager.Instance.currentData.powerLevel * 10;
        if (SaveManager.Instance.currentData.gold >= damageCost)
        {
            SaveManager.Instance.currentData.gold -= damageCost;
            SaveManager.Instance.currentData.powerLevel += 1;
            SaveManager.Instance.Save();
            //Shopui update
            shopUI.UpdateUI();
        }
    }
}
