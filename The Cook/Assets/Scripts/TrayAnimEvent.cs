using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayAnimEvent : MonoBehaviour
{
    public Animator anim;

    public Transform plate;
    public Transform fryingPan;
    public GameObject allVegetale;
    public GameObject decor;
    public GameObject decorController;

    public GameObject imageSliderBg;
    public void TrayAnimEnd()
    {
        if (AppDelegate.SharedManager().orderType == OrderType.Salad)
        {
            allVegetale.transform.SetParent(plate.transform);
        }
        else if (AppDelegate.SharedManager().orderType == OrderType.Stew)
        {
            allVegetale.transform.SetParent(fryingPan.transform);
        }
        decor.SetActive(true);
        decorController.SetActive(true);
    }

    public void ActiveFryingPan()
    {
        imageSliderBg.SetActive(true);
    }

    public void PlayTrayAnim()
    {
        if (AppDelegate.SharedManager().orderType == OrderType.Salad)
        {
            anim.SetBool("isPlay", true);
        }
        else if (AppDelegate.SharedManager().orderType == OrderType.Stew)
        {
            anim.SetTrigger("ToPan");
        }
    }

}
