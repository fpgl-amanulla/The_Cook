using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSelector : MonoBehaviour
{
    public Transform trayTransform;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //var position = trayTransform.position;
                //position.x += Random.Range(-1, 1);
                //position.z += Random.Range(-1, 1);
                if (hit.transform.CompareTag("Vegetable"))
                {
                    TweenManager.JumpObject(hit.transform.gameObject, new Vector3(
                         trayTransform.position.x , trayTransform.position.y, trayTransform.position.z 
                        )
                        , 0.5f, 1.0f);
                }
            }
        }
    }
}
