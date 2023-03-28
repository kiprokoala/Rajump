using System;
using UnityEngine;

public class Level03 : MonoBehaviour
{
    void Start()
    {
        GameObject empty = new GameObject();
        Instantiate(empty, new Vector3(0,0,0), Quaternion.identity);
        empty.AddComponent(Type.GetType("itemCollider"));
        BoxCollider2D bx = empty.AddComponent<BoxCollider2D>();
        bx.isTrigger = true;
        SpriteRenderer sp = empty.AddComponent<SpriteRenderer>();

        switch (DialogTrigger.instance.creatureName)
        {
            case "Vampire":
                sp.sprite = ItemManaging.instance.cape;
                break;
            case "Witch":
                sp.sprite = ItemManaging.instance.hat;
                break;
        }
    }
}
