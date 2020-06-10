using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (AppDelegate.SharedManager().orderType == OrderType.Icecream)
        {
            if (collision.collider.CompareTag("Ice"))
            {
                Destroy(collision.transform.GetComponent<Rigidbody>());
                collision.transform.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

}
