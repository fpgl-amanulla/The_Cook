using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance = null;

    public Transform mainTransform;
    public Transform kitchenTransform;
    public Transform decorTransform;
    public Transform knifeTransform;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public IEnumerator GoToMainTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Working");
        transform.position = mainTransform.position;
        transform.rotation = mainTransform.rotation;
    }
    public IEnumerator GoToKitchenTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = kitchenTransform.position;
        transform.rotation = kitchenTransform.rotation;
    }
    public IEnumerator GoToDecorTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(decorTransform.position, 1.0f);
        transform.DORotateQuaternion(decorTransform.rotation, 1.0f);
        UIManager.Instance.btnDone.gameObject.SetActive(false);
    }
    public IEnumerator GoToKnifeTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(knifeTransform.position, 1.0f);
        transform.DORotateQuaternion(knifeTransform.rotation, 1.0f);
        //transform.position = knifeTransform.position;
        //transform.rotation = knifeTransform.rotation;
    }
}
