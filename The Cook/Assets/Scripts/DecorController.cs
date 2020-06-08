using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorController : MonoBehaviour
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

    void Update()
    {
        mouseCurrentPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = mouseCurrentPosition;
        }

        if (Input.GetMouseButton(0))
        {
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

        }
    }
}
