using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speed;
    public Transform visuals;
    private Vector3 deviation;
    public float maxDragDistance = 40f;
    private Vector3 moveDirection = Vector3.forward;
    private Vector3 currentDirection = Vector3.forward;
    public float sensitivity = 150;
    public float turnTreshold = 15f;
    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;
    protected Quaternion targetRotation;
    [SerializeField] private float movementSmoothing;
    [SerializeField] private float rotationSmoothing;

    public Animator knifeAnim;
    private void Start()
    {
        knifeAnim = GetComponent<Animator>();
    }

    void Update()
    {
        mouseCurrentPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = mouseCurrentPosition;
        }

        if (Input.GetMouseButton(0))
        {
            knifeAnim.SetBool("isPlay", true);

            deviation = moveDirection * speed * Time.deltaTime;
            transform.position += deviation;

            float distance = (mouseCurrentPosition - mouseStartPosition).magnitude;
            if (distance > turnTreshold)
            {
                if (distance > sensitivity)
                {
                    mouseStartPosition = mouseCurrentPosition - (moveDirection * sensitivity);
                }

                currentDirection = -(mouseStartPosition - mouseCurrentPosition).normalized;
                moveDirection.x = Mathf.Lerp(moveDirection.x, currentDirection.x, movementSmoothing);
                moveDirection.z = Mathf.Lerp(moveDirection.z, currentDirection.y, movementSmoothing);
                moveDirection.y = 0f;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            knifeAnim.SetBool("isPlay", false);
        }
    }

    //public Animator knifeAnim;
    //private float speedModifier = .05f;
    //private void Start()
    //{
    //    knifeAnim = GetComponent<Animator>();
    //}

    //private void Update()
    //{
    //    if (Application.isEditor)
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            knifeAnim.SetBool("isPlay", true);
    //        }
    //        else if (Input.GetMouseButtonUp(0))
    //        {
    //            knifeAnim.SetBool("isPlay", false);
    //        }
    //    }

    //    if (Input.touchCount == 1)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            knifeAnim.SetBool("isPlay", true);
    //            transform.position = new Vector3(
    //                 transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime,
    //                 transform.position.y,
    //                 transform.position.z + touch.deltaPosition.y * speedModifier * Time.deltaTime
    //                );
    //        }
    //        else if (touch.phase == TouchPhase.Ended)
    //        {
    //            knifeAnim.SetBool("isPlay", false);
    //        }
    //    }
    //}
}
