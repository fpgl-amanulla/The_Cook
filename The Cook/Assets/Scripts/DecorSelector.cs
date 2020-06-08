using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DecorSelector : MonoBehaviour
{
    private float speedModifier = .1f;
    public Transform decor;
    public Transform DecorTransform;
    public Transform DecorIdle;
    private bool idle = true;
    public GameObject spice;
    public GameObject plateH;
    private int count = 0;
    private void Update()
    {

        //if (Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        Instantiate(spice, decor.transform.position, Quaternion.identity);
        //        //decor.transform.localPosition = new Vector3(
        //        //     Mathf.Clamp(decor.transform.localPosition.x, -1, 1) + touch.deltaPosition.x * speedModifier * Time.deltaTime,
        //        //     decor.transform.localPosition.y,
        //        //     Mathf.Clamp(decor.transform.localPosition.z, -.5f, .5f) + touch.deltaPosition.y * speedModifier * Time.deltaTime
        //        //    );
        //    }
        //    else if (touch.phase == TouchPhase.Ended)
        //    {

        //    }
        //}
        if (count < 150)
        {
            if (Input.GetMouseButton(0) && idle == false)
            {
                count++;
                GameObject g = Instantiate(spice, decor.transform.position, Quaternion.identity);
                g.transform.SetParent(plateH.transform);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Decor"))
                {
                    if (idle == true)
                    {
                        hit.transform.DOMove(DecorTransform.position, 1.0f).OnComplete(Complete);
                        hit.transform.DORotate(new Vector3(90, transform.position.y, transform.position.z), 1.0f);
                    }
                    //else if(idle == false)
                    //{
                    //    hit.transform.DOMove(DecorIdle.position, 1.0f);
                    //    idle = true;
                    //}
                    UIManager.Instance.btnDone.gameObject.SetActive(true);
                    UIManager.Instance.btnDone.onClick.RemoveAllListeners();
                    UIManager.Instance.btnDone.onClick.AddListener(() => DecorDone());
                }
            }
        }
    }

    private void Complete()
    {
        idle = false;
    }

    private void DecorDone()
    {
        Destroy(decor.gameObject);
        UIManager.Instance.btnDone.gameObject.SetActive(false);
        GameManager.Instance.plate.DOLocalMove(new Vector3(-0.012548f, 0.507f, .5f), 1.5f);
    }
}
