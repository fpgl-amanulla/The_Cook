using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollision : MonoBehaviour
{
    public Image fillImage;
    int count = 0;
    private int totalAmount = 43;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Vegetable"))
        {
            count++;
            other.transform.SetParent(this.transform);
            fillImage.fillAmount = (float)count / totalAmount;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
