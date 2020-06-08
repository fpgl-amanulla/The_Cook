using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public TrayAnimEvent trayAnim;
    public GameObject knife;
    private bool isDone = false;
    public ParticleSystem cuttingEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Vegetable"))
        {
            cuttingEffect.Play();
            if (isDone == false)
            {
                isDone = true;
                UIManager.Instance.btnDone.onClick.RemoveAllListeners();
                UIManager.Instance.btnDone.gameObject.SetActive(true);
                UIManager.Instance.btnDone.onClick.AddListener(() => CuttingDone());
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Vegetable"))
    //    {
    //        UIManager.Instance.btnDone.gameObject.SetActive(true);
    //        UIManager.Instance.btnDone.onClick.RemoveAllListeners();
    //        UIManager.Instance.btnDone.onClick.AddListener(() => CuttingDone());
    //    }
    //}

    private void CuttingDone()
    {
        trayAnim.PlayTrayAnim();
        StartCoroutine(CameraController.Instance.GoToDecorTransform(0f));
        StartCoroutine(Wait());
        UIManager.Instance.btnDone.gameObject.SetActive(false);
        knife.SetActive(false);
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(6.0f);
        GameManager.Instance.knife.SetActive(false);

    }
}
