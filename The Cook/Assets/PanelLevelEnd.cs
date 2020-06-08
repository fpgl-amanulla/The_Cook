using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelLevelEnd : MonoBehaviour
{
    public Button btnNext;

    private void Start()
    {
        btnNext.onClick.AddListener(() => NextCallback());
    }

    private void NextCallback()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
