using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Saving()
    {
        PlayerPrefs.SetInt("coins", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("life", PlayerHealth.instance.currentHealth);
    }

    public void ChargingCoins()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coins", 0);
        Inventory.instance.UpdateTextUI();
    }

    public void ChargingLife()
    {
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("life", 5);
        PlayerHealth.instance.lifebar.SetMaxHealth(5);
        PlayerHealth.instance.lifebar.setHealth(PlayerHealth.instance.currentHealth);
    }
}
