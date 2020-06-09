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
        txtOrderNo.text = "Order " + AppDelegate.SharedManager().templevelCounter;
        btnNext.onClick.AddListener(() => NextCallback());
    }

    private void NextCallback()
    {
        AppDelegate.SharedManager().templevelCounter += 1;
        AppDelegate.SharedManager().levelCounter += 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
