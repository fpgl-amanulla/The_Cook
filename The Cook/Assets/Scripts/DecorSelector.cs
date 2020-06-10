using DG.Tweening;
using System;
using System.Collections;
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
    public GameObject iceCreamTray;
    private int count = 0;
    private int limit = 50;
    public GameObject panelLevelEnd;

    private float time = 0f;
    private float nextSpawnTime = .05f;

    public Transform transformOnTray;
    public GameObject iceBall;
    public GameObject panelIceSlider;

    private void Start()
    {
        if (AppDelegate.SharedManager().orderType == OrderType.Icecream)
            limit = 200;
    }

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
        if (count < limit)
        {
            if (Input.GetMouseButton(0) && idle == false)
            {
                time += Time.deltaTime;
                if (time > nextSpawnTime)
                {
                    count++;
                    time = 0;
                    if (spice != null && decor != null)
                    {
                        GameObject g = Instantiate(spice, decor.transform.position, Quaternion.identity);
                        if (AppDelegate.SharedManager().orderType == OrderType.Icecream)
                        {
                            g.transform.SetParent(iceCreamTray.transform);
                        }
                        else
                            g.transform.SetParent(plateH.transform);
                    }
                }
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
                        decor.GetComponent<DecorController>().enabled = true;
                    }
                    //else if(idle == false)
                    //{
                    //    hit.transform.DOMove(DecorIdle.position, 1.0f);
                    //    idle = true;
                    //}
                    UIManager.Instance.btnDone.onClick.RemoveAllListeners();
                    UIManager.Instance.btnDone.gameObject.SetActive(true);
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
        if (AppDelegate.SharedManager().orderType == OrderType.Icecream)
        {
            TweenManager.JumpObject(iceBall, transformOnTray.position, 1.0f, .5f);
            CameraController.Instance.GoToIceCreamTransform();
            iceBall.transform.GetComponent<IceBallController>().enabled = true;
            AppDelegate.SharedManager().totalIceCount = count;
            panelIceSlider.SetActive(true);
        }
        else
            GameManager.Instance.plate.DOLocalMove(new Vector3(-0.012548f, 0.507f, .5f), 1.5f).OnComplete(OrderComplete);
    }

    private void OrderComplete()
    {
        StartCoroutine(WaitForLevelEnd());
    }

    IEnumerator WaitForLevelEnd()
    {
        yield return new WaitForSeconds(1.0f);
        panelLevelEnd.SetActive(true);
    }
}
