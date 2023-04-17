using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public Animator FadeSystem;

    public AudioClip audioClip;

    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.takeDamage(1);
            AudioManager.instance.PlayClip(audioClip, transform.position);
            StartCoroutine(replacePlayer(collision));
        }
    }

    public IEnumerator replacePlayer(Collider2D collision)
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.3f);
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;
    }
}
