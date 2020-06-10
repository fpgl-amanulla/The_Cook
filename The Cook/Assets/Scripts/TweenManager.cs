using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenManager : MonoBehaviour
{
    private static Image imgFade;

    public static void JumpObject(GameObject gameObject, Vector3 endPos, float jumpPower, float durationTime, int numberOfJump = 1, bool isLocal = false)
    {
        if (isLocal)
        {
            gameObject.transform.DOLocalJump(endPos, jumpPower, numberOfJump, durationTime);
        }
        else
            gameObject.transform.DOJump(endPos, jumpPower, numberOfJump, durationTime);
    }
    public static void DoFade(Image _imgFade, float durationTime)
    {
        imgFade = _imgFade;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_imgFade.DOFade(1, durationTime)).Append(_imgFade.DOFade(0, durationTime)).OnComplete(DoFadeComplete);
    }

    private static void DoFadeComplete()
    {
        Destroy(imgFade);
    }

}
