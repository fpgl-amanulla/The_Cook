using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public List<GameObject> vegetableList = new List<GameObject>();

    public GameObject knife;
    public GameObject drawer;

    public Transform plate;
    private void Start()
    {
        AppDelegate appDelegate = AppDelegate.SharedManager();

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

    }

}
