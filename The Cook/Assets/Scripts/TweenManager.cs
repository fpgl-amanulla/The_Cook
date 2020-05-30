using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    public static void JumpObject(GameObject gameObject, Vector3 endPos, float jumpPower, float durationTime, int numberOfJump = 1)
    {
        gameObject.transform.DOLocalJump(endPos, jumpPower, numberOfJump, durationTime);
    }
}
