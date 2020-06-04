using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public Animator anim;

    public void StartCooking()
    {
        anim.SetBool("isCooking", true);
    }
    public void StopCooking()
    {
        anim.SetBool("isCooking", false);
    }
    public void CookingComplete()
    {
        anim.SetBool("isComplete", true);
    }

}
