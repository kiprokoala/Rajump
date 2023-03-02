using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject SettingsUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        PlayerMovement.instance.enabled = false;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        PlayerMovement.instance.enabled = true;
    }

    public void RetryButton()
    {
        Inventory.instance.removeCoins(CurrentSceneManager.instance.coinsPickedUpInCurrentScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        Time.timeScale = 1;
        gameIsPaused = false;
        PlayerMovement.instance.enabled = true;
    }

    public void MainMenuButton()
    {
        Resume();
        SceneManager.LoadScene(1);
    }

    public void OpenSettingsWindow()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        SettingsUI.SetActive(false);
    }
}
