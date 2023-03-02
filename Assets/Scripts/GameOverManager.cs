using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameObjectUI;

    public static GameOverManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void onPlayerDeath()
    {
        gameObjectUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.removeCoins(CurrentSceneManager.instance.coinsPickedUpInCurrentScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
