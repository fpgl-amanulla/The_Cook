using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;

    [Header("Buttons")]
    public Button btnStart;

    [Space(1)]
    [Header("Gameobjects")]
    public GameObject panelStart;
    public GameObject imgFade;


    private void Start()
    {
        btnStart.onClick.AddListener(() => StartCallBack());
    }

    private void StartCallBack()
    {
        panelStart.SetActive(false);
        GameObject fadeImage = Instantiate(imgFade, canvas.transform);
        TweenManager.DoFade(fadeImage.GetComponent<Image>(), 2.5f);
        StartCoroutine(CameraController.Instance.GoToKitchenTransform(2.0f));
    }
}
