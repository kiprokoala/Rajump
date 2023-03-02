using Unity.VisualScripting;
using UnityEngine;

public class weakSpot : MonoBehaviour
{
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClip(audioClip, transform.position);
            collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, -(collision.attachedRigidbody.velocity.y)+5);
            Destroy(transform.parent.parent.gameObject);
        }
    }
}