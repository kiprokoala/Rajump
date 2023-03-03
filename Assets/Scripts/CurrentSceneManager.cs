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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Inventory.instance.removeCoins(CurrentSceneManager.instance.coinsPickedUpInCurrentScene);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Respawn();
        }
    }
}