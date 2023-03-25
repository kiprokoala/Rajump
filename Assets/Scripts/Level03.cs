using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Level03 : MonoBehaviour
{
    public GameObject ghost;
    public GameObject werewolf;

    void Start()
    {
        GameObject empty = new GameObject();
        Instantiate(empty, new Vector3(0,0,0), Quaternion.identity);
        empty.AddComponent(Type.GetType("itemCollider"));
    }
}
