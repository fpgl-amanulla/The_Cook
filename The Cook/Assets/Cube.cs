using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
        TweenManager.JumpObject(this.gameObject, new Vector3(5, 1, 0), 5f, 2.0f);
    }
}
