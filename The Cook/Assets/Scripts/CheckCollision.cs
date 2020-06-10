using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollision : MonoBehaviour
{
    public Image fillImage;
    int count = 0;
    private int totalAmount = 1;

    private bool isDone = false;
    public Transform iceBall;

    public GameObject panelIceSlider;
    public GameObject panelLevelEnd;
    public Transform cam;
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ice"))
        {
            count++;
            other.transform.tag = "Untagged";
            other.transform.SetParent(this.transform);
            fillImage.fillAmount = (float)count / totalAmount;
            if (!isDone)
            {
                isDone = true;
                totalAmount = AppDelegate.SharedManager().totalIceCount;
                UIManager.Instance.btnDone.onClick.RemoveAllListeners();
                UIManager.Instance.btnDone.gameObject.SetActive(true);
                UIManager.Instance.btnDone.onClick.AddListener(() => IceDone());
            }
        }
    }

    private void IceDone()
    {
        UIManager.Instance.btnDone.gameObject.SetActive(false);
        panelIceSlider.SetActive(false);
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        TweenManager.JumpObject(this.transform.gameObject, Vector3.zero, 5.0f, 1.0f, 1, true);
        CameraController.Instance.TweenToMainTransform();
        StartCoroutine(Wait());

        //this.transform.parent.DOMove(iceBall.position, 1.0f);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        panelLevelEnd.SetActive(true);
    }
    /*private void OnCollisionEnter(Collision collision)
{
   if (collision.transform.CompareTag("Vegetable"))
   {
       count++;
       collision.transform.SetParent(this.transform);
       fillImage.fillAmount = (float)count / totalAmount;
   }
}*/
}
