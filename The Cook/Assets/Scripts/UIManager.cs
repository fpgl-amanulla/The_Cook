using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    public GameObject canvas;
    public Button btnDone;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

    }

}
