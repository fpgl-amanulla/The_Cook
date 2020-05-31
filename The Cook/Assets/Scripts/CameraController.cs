using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance = null;

    public Transform mainTransform;
    public Transform kitchenTransform;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public IEnumerator GoToMainTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = mainTransform.position;
        transform.rotation = mainTransform.rotation;
    }
    public IEnumerator GoToKitchenTransform(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = kitchenTransform.position;
        transform.rotation = kitchenTransform.rotation;
    }
}
