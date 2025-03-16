using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;
    public float ballSpeed = 0.0f;

    public float minVelocity = 1.0f;
    public float maxVelocity = 10.0f;

    public GameObject arrow;

    public AudioSource ballHit;

    public GameObject golfBall;

    public GameObject mainCamera;

    public BallForce strike;
    public BallForce force;

    public Slider slider;
    public float sliderTimer;

    public Vector3 velocity;
    Vector3 placeToLookAt = Vector3.zero;

    public AnimationCurve easeInCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private bool isCharging = false;
    private bool isRecharging = false;

    private float rechargerTimer = 0.0f;

    private float smoothTime = 0.1f;
    private Vector3 currentVelocity;

    public LevelUi levelUi;

    public float playerSpeed;

    void Start()
    {
        golfBall = GameObject.FindGameObjectWithTag("GolfBall");

        if (controller.isGrounded)
        {
            velocity.y = 0.0f;
        }

        levelUi = GameObject.FindGameObjectWithTag("LevelUi").GetComponent<LevelUi>();
    }

    void Update()
    {
        if (levelUi.IsGamePaused())
        {
            return;
        }

        UpdatePosition();

        if (Input.GetButton("Jump"))
        {
            if (!isRecharging)
            {
                Vector3 playerToBall = golfBall.transform.position - transform.position;
                playerToBall *= 2;
                placeToLookAt = new Vector3(playerToBall.x, 0, playerToBall.z);

                sliderTimer += Time.deltaTime;
                isRecharging = false;
                rechargerTimer = 0.0f;

                if (!isCharging)
                {
                    easeInCurve.ClearKeys();
                    easeInCurve.AddKey(0.0f, slider.value);
                    easeInCurve.AddKey(1.0f / (1.0f - slider.value), 1.0f);
                }

                isCharging = true;
            }
        }

        UpdateSlider();

        if (Input.GetButtonUp("Jump"))
        {
            if (isCharging)
            {
                ballHit.Play();
                arrow.SetActive(false);

                ballSpeed = slider.value * maxVelocity + minVelocity;

                golfBall.GetComponent<Rigidbody>().linearVelocity = new
                Vector3(placeToLookAt.x * (ballSpeed / 10.0f), 0.0f, placeToLookAt.z * (ballSpeed / 10.0f));

                ballSpeed = 0.0f;
                strike.AddStroke();

                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, slider.value);
                easeInCurve.AddKey(0.3f, 0.0f);
                sliderTimer = 0.0f;
                rechargerTimer = 0.0f;
                isCharging = false;
                isRecharging = true;

                if (slider.value > 0.92f)
                {
                    rechargerTimer -= 0.1f;
                    levelUi.MaxForce();
                }
            }
        }
    }

    private void UpdateSlider()
    {
        if (isCharging)
        {
            float sineValue = easeInCurve.Evaluate(sliderTimer);
            slider.value = sineValue;
        }

        if (isRecharging)
        {
            rechargerTimer += Time.deltaTime;
            float sineValue = easeInCurve.Evaluate(rechargerTimer);
            slider.value = sineValue;

            if (slider.value == 0.0f)
            {
                isRecharging = false;
                rechargerTimer = 0.0f;
                sliderTimer = 0.0f;

                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, 0.0f);
                easeInCurve.AddKey(1.0f, 1.0f);
            }
        }

        if (isCharging)
        {
            if (slider.value == 1.0f)
            {
                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, 1.0f);
                easeInCurve.AddKey(1.0f, 0.0f);
                sliderTimer = 0.0f;
            }

            if (slider.value == 0.0f)
            {
                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, 0.0f);
                easeInCurve.AddKey(1.0f, 1.0f);
                sliderTimer = 0.0f;
            }
        }
    }


    private void UpdatePosition()
    {
        velocity = controller.velocity;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = mainCamera.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 targetVelocity = (right * x + forward * z) * playerSpeed;

        Vector3 smoothedVelocity = Vector3.SmoothDamp(velocity, targetVelocity, ref currentVelocity, smoothTime);

        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * Time.deltaTime * 5.0f);
        }

        controller.Move(smoothedVelocity * Time.deltaTime);
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
