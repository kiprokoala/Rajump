using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite checkpoint_checked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetComponent<SpriteRenderer>().sprite = checkpoint_checked;
            CurrentSceneManager.instance.respawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
