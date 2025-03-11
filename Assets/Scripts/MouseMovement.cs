using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 mMouseTurn;

    public float xRotation = 0.0f;
    public float mouseSensitivity = 1.0f;

    private Vector2 currentRotation;
    private Vector2 rotationVelocity;

    public float smoothTime; // Smoothing factor

    void Start()
    {
        xRotation = 0.0f;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Accumulate input
        mMouseTurn.x += mouseX;
        mMouseTurn.y -= mouseY; // Inverting Y-axis

        // Clamp vertical rotation to prevent flipping
        mMouseTurn.y = Mathf.Clamp(mMouseTurn.y, -89f, 89f);

        // Smooth transition using Lerp
        currentRotation.x = Mathf.Lerp(currentRotation.x, mMouseTurn.x, smoothTime);
        currentRotation.y = Mathf.Lerp(currentRotation.y, mMouseTurn.y, smoothTime);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0.0f);
    }

    public void SetMouseSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}
