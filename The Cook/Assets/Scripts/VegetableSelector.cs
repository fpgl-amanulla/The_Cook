using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class VegetableSelector : MonoBehaviour
{
    public Transform[] trayTransform;
    int c = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Vegetable"))
                {
                    GameManager.Instance.vegetableList.Add(hit.transform.gameObject);
                    TweenManager.JumpObject(hit.transform.gameObject, new Vector3(
                           trayTransform[c].position.x + UnityEngine.Random.Range(.1f, -.1f), trayTransform[c].position.y, trayTransform[c].position.z + UnityEngine.Random.Range(.1f, -.1f)
                          )
                          , 0.5f, 1.0f);
                    hit.transform.SetParent(trayTransform[c]);
                    UIManager.Instance.btnDone.gameObject.SetActive(true);
                    UIManager.Instance.btnDone.onClick.RemoveAllListeners();
                    UIManager.Instance.btnDone.onClick.AddListener(() => SelectDone());
                }
            }
        }
    }

    private void SelectDone()
    {
        GameManager.Instance.knife.SetActive(true);
        GameManager.Instance.drawer.SetActive(false);
        Drawer.Instance.CloseDrawer();
        StartCoroutine(CameraController.Instance.GoToKnifeTransform(0));
        UIManager.Instance.btnDone.gameObject.SetActive(false);
        this.GetComponent<VegetableSelector>().enabled = false;
    }
}
