using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private LevelUi levelUi;

    [SerializeField]
    private Vector2 mMouseTurn;

    public float xRotation = 0.0f;
    public float mouseSensitivity = 1.0f;

    private Vector2 currentRotation;
    private Vector2 rotationVelocity;

    public float smoothTime;

    void Start()
    {
        xRotation = 0.0f;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;

        levelUi = GameObject.FindGameObjectWithTag("LevelUi").GetComponent<LevelUi>();
    }

    void Update()
    {
        if (levelUi.IsGamePaused())
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        mMouseTurn.x += mouseX;
        mMouseTurn.y -= mouseY;

        mMouseTurn.y = Mathf.Clamp(mMouseTurn.y, -89f, 89f);

        currentRotation.x = Mathf.Lerp(currentRotation.x, mMouseTurn.x, smoothTime);
        currentRotation.y = Mathf.Lerp(currentRotation.y, mMouseTurn.y, smoothTime);

        transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0.0f);
    }

    public void SetMouseSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}
