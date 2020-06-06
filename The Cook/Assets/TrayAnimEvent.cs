using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayAnimEvent : MonoBehaviour
{
    public Animator anim;

    public Transform plate;
    public GameObject allVegetale;

    public void TrayAnimEnd()
    {
        Debug.Log("TrayAnim");
        allVegetale.transform.SetParent(plate.transform);
    }

    public void PlayTrayAnim()
    {
        anim.SetBool("isPlay", true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);

        
    }
}
