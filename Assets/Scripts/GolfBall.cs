using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Transform playerTransform;
    public Transform thisTransform;
    
    public Camera playerCamera;

    public Rigidbody thisRigidBody;

    private GameObject arrow;

    private void Start()
    {
        arrow = GetComponentInChildren<Transform>().gameObject;    
    }

    private void Update()
    {
        UpdateGolfBallOrientation();
        DisableArrowIfNoVelocity();
    }

    private void DisableArrowIfNoVelocity()
    {
        if (thisRigidBody.linearVelocity == Vector3.zero)
        {
            arrow.SetActive(true);
        }
    }

    private void UpdateGolfBallOrientation()
    {
        Vector3 playerToBall = playerTransform.position - transform.position;
        playerToBall *= 2;
        Vector3 placeToLookAt = playerToBall + playerTransform.position;
        transform.LookAt(new Vector3(placeToLookAt.x, transform.position.y, placeToLookAt.z));
    }
}
