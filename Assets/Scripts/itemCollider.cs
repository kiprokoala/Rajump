using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollider : MonoBehaviour
{
    public Sprite hat;
    public Sprite cape;

    public GameObject Player;
    
    private void OnCollisionEnter(Collision collision)
    {
        //à mettre dans un collider
        GameObject empty = new GameObject();
        empty.transform.parent = Player.transform;
        empty.AddComponent<SpriteRenderer>();

        SpriteRenderer sp = empty.GetComponent<SpriteRenderer>();
        Vector3 position = Player.transform.position;

        switch (DialogTrigger.instance.creatureName)
        {
            case "Vampire":
                position.y += 0.35f;
                sp.sprite = cape;
                PlayerMovement.instance.moveSpeed *= 2;
                break;
            case "Witch":
                position.y += 0.05f;
                position.x += 0.25f;
                sp.sprite = hat;
                PlayerMovement.instance.jumpForce *= 2;
                break;
        }

        empty.transform.position = position;
        sp.sortingOrder = 200;
    }
}
