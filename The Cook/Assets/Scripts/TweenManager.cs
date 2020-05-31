using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenManager : MonoBehaviour
{
    private static Image imgFade;

    public static void JumpObject(GameObject gameObject, Vector3 endPos, float jumpPower, float durationTime, int numberOfJump = 1)
    {
        gameObject.transform.DOJump(endPos, jumpPower, numberOfJump, durationTime);
    }
    public static void DoFade(Image _imgFade, float durationTime)
    {
        imgFade = _imgFade;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_imgFade.DOFade(1, durationTime)).Append(_imgFade.DOFade(0, durationTime)).OnComplete(Complete);
    }

    private static void Complete()
    {
        Destroy(imgFade);
    }

}
