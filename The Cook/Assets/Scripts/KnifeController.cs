using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public Animator knifeAnim;
    private float speedModifier = .05f;
    private void Start()
    {
        knifeAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButton(0))
            {
                knifeAnim.SetBool("isPlay", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                knifeAnim.SetBool("isPlay", false);
            }
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                knifeAnim.SetBool("isPlay", true);
                transform.position = new Vector3(
                     transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime,
                     transform.position.y,
                     transform.position.z + touch.deltaPosition.y * speedModifier * Time.deltaTime
                    );
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                knifeAnim.SetBool("isPlay", false);
            }
        }
    }
}
