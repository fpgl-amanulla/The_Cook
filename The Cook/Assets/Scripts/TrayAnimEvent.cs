using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayAnimEvent : MonoBehaviour
{
    public Animator anim;

    public Transform plate;
    public GameObject allVegetale;
    public GameObject decor;
    public GameObject decorController;

    public void TrayAnimEnd()
    {
        Debug.Log("TrayAnim");
        allVegetale.transform.SetParent(plate.transform);
        decor.SetActive(true);
        decorController.SetActive(true);
    }

    public void PlayTrayAnim()
    {
        anim.SetBool("isPlay", true);
    }

}
