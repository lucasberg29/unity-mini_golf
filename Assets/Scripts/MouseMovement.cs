using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float xRotation;
    public float mouseSensitivity = 10.0f;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Mouse X") * mouseSensitivity;
        playerTransform.Rotate(Vector3.up, xMovement);

        float yMovement = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation += yMovement;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(-xRotation, 0, 0);
    }

    public void setMouseSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}
