using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vegetable"))
        {
            other.transform.gameObject.AddComponent(typeof(Rigidbody));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Vegetable"))
        {
            collision.transform.GetComponent<Rigidbody>().isKinematic = false;
            UIManager.Instance.btnDone.gameObject.SetActive(true);
            UIManager.Instance.btnDone.onClick.RemoveAllListeners();
            UIManager.Instance.btnDone.onClick.AddListener(() => CuttingDone());
            //collision.transform.GetComponent<Rigidbody>().AddExplosionForce(100f, collision.transform.position, 10.0f);
        }
    }

    private void CuttingDone()
    {
        UIManager.Instance.btnDone.gameObject.SetActive(false);
        GameObject fadeImage = Instantiate(UIManager.Instance.imgFade, UIManager.Instance.canvas.transform);
        TweenManager.DoFade(fadeImage.GetComponent<Image>(), 2.5f);
        StartCoroutine(CameraController.Instance.GoToDecorTransform(2.0f));
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.tray.transform.position = GameManager.Instance.trayToPlate.transform.position;
        GameManager.Instance.tray.transform.rotation = GameManager.Instance.trayToPlate.transform.rotation;

        GameManager.Instance.VegetableFall();

        yield return new WaitForSeconds(6.0f);
        GameManager.Instance.knife.SetActive(false);

    }
}
