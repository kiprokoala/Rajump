using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemAtLoad : MonoBehaviour
{
    private void Start()
    {
        ItemManaging.instance.addItem(gameObject);
    }
}
