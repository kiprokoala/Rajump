using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadSpecificScene : MonoBehaviour
{
    public Animator FadeSystem;

    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadAndSaveData.instance.Saving();
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
