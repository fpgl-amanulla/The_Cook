using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance = null;

    public Transform mainTransform;
    public Transform kitchenForSalad;
    public Transform kitchenForStew;
    public Transform decorTransform;
    public Transform knifeTransformForSalad;
    public Transform knifeTransformForStew;
    public Transform fryingPanTransForm;


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
    public void GoToKitchen()
    {
        StartCoroutine(InitKitchen());
    }

    IEnumerator InitKitchen()
    {
        yield return new WaitForSeconds(1.5f);
        if (AppDelegate.SharedManager().orderType == OrderType.Salad)
        {
            transform.position = kitchenForSalad.position;
            transform.rotation = kitchenForSalad.rotation;
        }
        else if (AppDelegate.SharedManager().orderType == OrderType.Stew)
        {
            transform.position = kitchenForStew.position;
            transform.rotation = kitchenForStew.rotation;
        }
        yield return new WaitForSeconds(.5f);
        Drawer.Instance.OpenDrawer();
    }

    public IEnumerator GoToDecorTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(decorTransform.position, 1.0f);
        transform.DORotateQuaternion(decorTransform.rotation, 1.0f);
        //UIManager.Instance.btnDone.gameObject.SetActive(false);
    }

    public IEnumerator GoToFryingPanTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(fryingPanTransForm.position, 1.0f);
        transform.DORotateQuaternion(fryingPanTransForm.rotation, 1.0f);
        //UIManager.Instance.btnDone.gameObject.SetActive(false);
    }

    public IEnumerator GoToKnifeTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (AppDelegate.SharedManager().orderType == OrderType.Salad)
        {
            transform.DOMove(knifeTransformForSalad.position, 1.0f);
            transform.DORotateQuaternion(knifeTransformForSalad.rotation, 1.0f);
        }
        else if (AppDelegate.SharedManager().orderType == OrderType.Stew)
        {
            transform.DOMove(knifeTransformForStew.position, 1.0f);
            transform.DORotateQuaternion(knifeTransformForStew.rotation, 1.0f);
        }
        //transform.position = knifeTransform.position;
        //transform.rotation = knifeTransform.rotation;
    }
}
