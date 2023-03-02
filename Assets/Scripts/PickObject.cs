using UnityEngine;

public class PickObject : MonoBehaviour
{
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClip(audioClip, transform.position);
            Inventory.instance.addCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInCurrentScene++;
            Destroy(gameObject);
        }
    }
}
