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

    public Transform cameraTransform;
    public BallForce strike;
    public BallForce force;

    private bool isSliderGrowing = false;
    private bool isSliderShrinking = false;
    public Slider slider;
    public float sliderTimer;

    public Vector3 velocity;
    Vector3 placeToLookAt = Vector3.zero;

    public AnimationCurve easeInCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private bool isCharging = false;
    private bool isRecharging = false;

    private float rechargerTimer = 0.0f;



    void Start()
    {
        golfBall = GameObject.FindGameObjectWithTag("GolfBall");

        if (controller.isGrounded)
        {
            velocity.y = 0.0f;
        }
    }

    void Update()
    {
        UpdatePosition();

        if (Input.GetButton("Jump"))
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
                easeInCurve.AddKey(1.0f / ( 1.0f - slider.value), 1.0f);
            }

            isCharging = true;
        }

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
                isSliderShrinking = true;

                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, 1.0f);
                easeInCurve.AddKey(1.0f, 0.0f);
                sliderTimer = 0.0f;
            }

            if (slider.value == 0.0f)
            {
                isSliderShrinking = false;
                isSliderGrowing = true;

                easeInCurve.ClearKeys();
                easeInCurve.AddKey(0.0f, 0.0f);
                easeInCurve.AddKey(1.0f, 1.0f);
                sliderTimer = 0.0f;
            }
        }

        if (Input.GetButtonUp("Jump"))
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
        }
    }

    private void UpdatePosition()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * x) +
                       (transform.forward * z);
        controller.Move(moveDirection * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
