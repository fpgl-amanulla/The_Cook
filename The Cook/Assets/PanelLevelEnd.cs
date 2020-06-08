using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PanelLevelEnd : MonoBehaviour
{
    public Button btnNext;
    public TextMeshProUGUI txtOrderNo;

    private void Start()
    {
        txtOrderNo.text = "Order " + 1;
        btnNext.onClick.AddListener(() => NextCallback());
    }

    private void NextCallback()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
