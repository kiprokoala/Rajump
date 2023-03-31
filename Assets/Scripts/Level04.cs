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
                    break;
                case "Witch":
                    Instantiate(ItemManaging.instance.ghost, new Vector3(24f, -20f, 0), Quaternion.identity);
                    break;
            }
        }
        catch //This is just for tests
        {
            Instantiate(ItemManaging.instance.ghost, new Vector3(27f, -18f, 0), Quaternion.identity);
        }
    }
}