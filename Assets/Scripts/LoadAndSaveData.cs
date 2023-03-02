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
    }

    public void Charging()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coins", 0);
        Inventory.instance.UpdateTextUI();
    }
}
