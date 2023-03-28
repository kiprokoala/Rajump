using UnityEngine;

public class itemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //à mettre dans un collider
        GameObject empty = new GameObject();
        empty.transform.parent = collision.transform;

        SpriteRenderer sp = empty.AddComponent<SpriteRenderer>();
        Vector3 position = collision.transform.position;

        switch (DialogTrigger.instance.creatureName)
        {
            case "Vampire":
                position.y += 0.35f;
                sp.sprite = Level03.instance.cape;
                PlayerMovement.instance.moveSpeed *= 1.5f;
                break;
            case "Witch":
                position.y += 0.05f;
                position.x += 0.25f;
                sp.sprite = Level03.instance.hat;
                PlayerMovement.instance.jumpForce *= 2;
                break;
        }

        empty.transform.position = position;
        sp.sortingOrder = 200;
        Destroy(gameObject);
    }
}
