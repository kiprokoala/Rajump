using System;
using UnityEngine;

public class Level03 : MonoBehaviour
{
    public Sprite hat;
    public Sprite cape;

    public GameObject ghost;
    public GameObject werewolf;

    public static Level03 instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

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
                sp.sprite = cape;
                break;
            case "Witch":
                sp.sprite = hat;
                break;
        }
    }
}
