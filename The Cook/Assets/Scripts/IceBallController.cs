using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IceBallController : MonoBehaviour
{
    public float speed;
    public Transform visuals;
    private Vector3 deviation;
    public float maxDragDistance = 40f;
    private Vector3 moveDirection = Vector3.forward;
    private Vector3 currentDirection = Vector3.forward;
    public float sensitivity = 300f;
    public float turnTreshold = 15f;
    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;
    protected Quaternion targetRotation;
    [SerializeField] private float movementSmoothing;
    [SerializeField] private float rotationSmoothing;

    private void Start()
    {

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
            deviation = moveDirection * speed * 20f * Time.deltaTime;
            visuals.GetComponent<Rigidbody>().AddForce(deviation,ForceMode.Force);
            //transform.position += deviation;

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
            
            //targetRotation = Quaternion.LookRotation(moveDirection);

            //if (visuals.rotation != targetRotation)
            //{
            //    Quaternion deltaRotation = Quaternion.Euler(new Vector3(360f, 360f, 360f) * Time.smoothDeltaTime);
            //    visuals.rotation = Quaternion.Slerp(visuals.rotation, targetRotation * deltaRotation, rotationSmoothing);
            //}
            //if (moveDirection != Vector3.zero)
            //{

            //}
        }
        if (Input.GetMouseButtonUp(0))
        {
            visuals.GetComponent<Rigidbody>().velocity = Vector3.zero;
            visuals.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }


}
