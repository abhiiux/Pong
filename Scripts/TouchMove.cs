using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class TouchMove : MonoBehaviour
{
    public Transform leftPaddle;  // Assign in Inspector
    public Transform rightPaddle; // Assign in Inspector
    public float paddleSpeed = 10f;

    private Camera mainCamera;
    private int leftTouchID = -1;
    private int rightTouchID = -1;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPosition = GetTouchWorldPosition(touch.position);

            // Handle Touch Phases
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2 && leftTouchID == -1)
                    {
                        leftTouchID = touch.fingerId;
                    }
                    else if (touch.position.x >= Screen.width / 2 && rightTouchID == -1)
                    {
                        rightTouchID = touch.fingerId;
                    }
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (touch.fingerId == leftTouchID)
                    {
                        MovePaddle(leftPaddle, touchPosition);
                    }
                    else if (touch.fingerId == rightTouchID)
                    {
                        MovePaddle(rightPaddle, touchPosition);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (touch.fingerId == leftTouchID)
                    {
                        leftTouchID = -1;
                    }
                    else if (touch.fingerId == rightTouchID)
                    {
                        rightTouchID = -1;
                    }
                    break;
            }
        }
    }

    Vector3 GetTouchWorldPosition(Vector2 screenPosition)
    {
        Vector3 touchPosScreen = new Vector3(screenPosition.x, screenPosition.y, Mathf.Abs(mainCamera.transform.position.z));
        return mainCamera.ScreenToWorldPoint(touchPosScreen);
    }

    void MovePaddle(Transform paddle, Vector3 touchPosition)
    {
        // Restrict movement to Y-axis
        Vector3 newPosition = paddle.position;
        newPosition.y = Mathf.Lerp(paddle.position.y, touchPosition.y, Time.deltaTime * paddleSpeed);
        paddle.position = newPosition;
    }
}

