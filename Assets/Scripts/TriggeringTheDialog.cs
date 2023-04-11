using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringTheDialog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogTrigger.instance.isInRange = true;
            DialogTrigger.instance.creatureName = tag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogTrigger.instance.isInRange = false;
        }
    }
}
