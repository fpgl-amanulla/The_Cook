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

    [Header("Buttons")]
    public Button btnStart;
    public Button btnDone;

    [Space(1)]
    [Header("Gameobjects")]
    public GameObject panelStart;
    public GameObject imgFade;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        btnStart.onClick.AddListener(() => StartCallBack());
    }

    private void StartCallBack()
    {
        panelStart.SetActive(false);
        GameObject fadeImage = Instantiate(imgFade, canvas.transform);
        TweenManager.DoFade(fadeImage.GetComponent<Image>(), 1.5f);
        StartCoroutine(CameraController.Instance.GoToKitchenTransform(1.5f));
    }
}
