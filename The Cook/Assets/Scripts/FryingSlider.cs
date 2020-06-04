using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class FryingSlider : MonoBehaviour
{
    public FryingPan pan;
    public GameObject[] panChild;
    public Image imgSlide;
    public Transform cam;
    public GameObject plateSmoke;

    private float cookingTime = 10.0f;
    float time = 0;
    public float timeCount = 0;

    public GameObject plate;

    private bool isComplete = false;
    private void Update()
    {
        Vector2 pos = new Vector2(imgSlide.rectTransform.anchoredPosition.x, imgSlide.rectTransform.anchoredPosition.y);
        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                timeCount++;
                if (timeCount >= cookingTime)
                {
                    if (isComplete == false)
                    {
                        pan.CookingComplete();
                        StartCoroutine(SetParent());
                        cam.DOMove(new Vector3(3.8f, cam.position.y, cam.position.z), 1.0f);
                        imgSlide.gameObject.SetActive(false);
                        imgSlide.transform.parent.GetComponent<Image>().enabled = false;

                        isComplete = true;
                    }
                }
            }

            if (pos.x < 380)
            {
                pos.x += Random.Range(1, 1.5f);
            }
            if (pos.x > 50)
            {
                //Debug.Log("Fire On");
                pan.StartCooking();
            }
            imgSlide.rectTransform.anchoredPosition = pos;
        }
        else
        {
            if (pos.x > 0)
            {
                pos.x -= Random.Range(1, 2f);
            }
            if (pos.x < 50)
            {
                //Debug.Log("Fire Off");
                pan.StopCooking();
            }
            imgSlide.rectTransform.anchoredPosition = pos;
        }

        if (Input.GetMouseButtonDown(1))
        {
            pan.CookingComplete();
        }

    }

    public IEnumerator SetParent()
    {
        yield return new WaitForSeconds(1.50f);
        foreach (var item in panChild)
        {
            item.transform.SetParent(plate.transform);
        }
        plateSmoke.SetActive(true);
    }
}
