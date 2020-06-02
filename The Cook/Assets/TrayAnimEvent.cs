using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayAnimEvent : MonoBehaviour
{
    public Animator anim;

    public void TrayAnimEnd()
    {
        
        Debug.Log("TrayAnim");
    }

    public void PlayTrayAnim()
    {
        anim.SetBool("isPlay", true);
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.VegetableFall();
    }
}
