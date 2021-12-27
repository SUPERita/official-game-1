using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance { get; private set; }

    public Material playerMaterial;
    public bool playerExplosion = false;

    private void Awake()
    {
        Instance = this;
    }




}
