using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04 : MonoBehaviour
{
    private void Start()
    {

        try
        {
            switch (DialogTrigger.instance.creatureName)
            {
                case "Vampire":
                    Instantiate(ItemManaging.instance.werewolf, new Vector3(28f, -22f, 0), Quaternion.identity);
                    Instantiate(ItemManaging.instance.werewolf, new Vector3(51f, 0, 0), Quaternion.identity);
                    break;
                case "Witch":
                    Instantiate(ItemManaging.instance.ghost, new Vector3(24f, -20f, 0), Quaternion.identity);
                    Instantiate(ItemManaging.instance.ghost, new Vector3(47f, 2f, 0), Quaternion.identity);
                    break;
            }
        }
        catch //This is just for tests
        {

        }
    }
}