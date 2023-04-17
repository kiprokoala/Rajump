using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPickedUpInCurrentScene;
    public Vector3 respawnPoint;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Start()
    {
        PlayerMovement.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("posx"), PlayerPrefs.GetFloat("posy"), 0);
        PlayerPrefs.SetFloat("posx", -5f);
        PlayerPrefs.SetFloat("posy", 0);
        coinsPickedUpInCurrentScene = PlayerPrefs.GetInt("coinsCollected");
        removeCoinsCollected();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
                Inventory.instance.removeCoins(instance.coinsPickedUpInCurrentScene);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("life");
            PlayerHealth.instance.lifebar.setHealth(PlayerHealth.instance.currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetFloat("posx", instance.respawnPoint.x);
            PlayerPrefs.SetFloat("posy", instance.respawnPoint.y);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("coins", Inventory.instance.coinsCount);
        }
    }
}
