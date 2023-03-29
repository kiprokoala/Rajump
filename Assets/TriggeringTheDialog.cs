using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringTheDialog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogTrigger.instance.isInRange = true;
        DialogTrigger.instance.creatureName = tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogTrigger.instance.isInRange = false;
        DialogTrigger.instance.creatureName = "";
    }
}
