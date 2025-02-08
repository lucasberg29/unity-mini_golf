using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    private GameObject player;
    
    public Camera playerCamera;

    public Rigidbody thisRigidBody;

    private GameObject arrow;

    private void Start()
    {
        arrow = GetComponentInChildren<Transform>().gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
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
        Vector3 playerToBall = player.transform.position - transform.position;
        playerToBall *= 2;
        Vector3 placeToLookAt = playerToBall + player.transform.position;
        transform.LookAt(new Vector3(placeToLookAt.x, transform.position.y, placeToLookAt.z));
    }
}
