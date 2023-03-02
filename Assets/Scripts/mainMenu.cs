using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject settingsWindow;

    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseButton()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
