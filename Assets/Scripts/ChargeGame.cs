using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeGame : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("coins", 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
