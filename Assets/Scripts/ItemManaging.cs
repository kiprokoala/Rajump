using UnityEditor;
using UnityEngine;

public class ItemManaging : MonoBehaviour
{
    public Sprite hat;
    public Sprite cape;

    public GameObject ghost;
    public GameObject werewolf;

    public static ItemManaging instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void addItem(GameObject player)
    {
        GameObject empty = new GameObject();
        empty.transform.parent = player.transform;

        SpriteRenderer sp = empty.AddComponent<SpriteRenderer>();
        Vector3 position = player.transform.position;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        sp.flipX = rb.velocity.x <= -0.1f || (rb.velocity.x < 0.1f && sp.flipX);
        if(DialogTrigger.instance.creatureName != "")
        {
            switch (DialogTrigger.instance.creatureName)
            {
                case "Vampire":
                    position.y += 0.35f;
                    sp.sprite = cape;
                    PlayerMovement.instance.moveSpeed *= 1.5f;
                    break;
                case "Witch":
                    position.y += 0.05f;
                    position.x += 0.25f;
                    sp.sprite = hat;
                    PlayerMovement.instance.jumpForce *= 1.5f;
                    break;
            }
        }
        else //This is just for tests / Can be a try catch
        {
            switch (PlayerPrefs.GetInt("path"))
            {
                case 0:
                    position.y += 0.35f;
                    sp.sprite = cape;
                    PlayerMovement.instance.moveSpeed *= 1.5f;
                    break;
                case 1:
                    position.y += 0.05f;
                    position.x += 0.25f;
                    sp.sprite = hat;
                    PlayerMovement.instance.jumpForce *= 1.5f;
                    break;
            }
        }

        empty.transform.position = position;
        sp.sortingOrder = 200;
    }
}
