using UnityEngine;

public class itemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemManaging.instance.addItem(collision.gameObject);
        Destroy(gameObject);
    }
}
