using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Transform playerTransform;
    public Transform thisTransform;
    
    public Camera playerCamera;

    public Rigidbody thisRigidBody;

    public GameObject arrow;

    private void Update()
    {
        Vector3 playerToBall = playerTransform.position - transform.position;
        playerToBall *= 2;
        Vector3 placeToLookAt = playerToBall + playerTransform.position;
        transform.LookAt(new Vector3(placeToLookAt.x, transform.position.y, placeToLookAt.z));

        if (thisRigidBody.velocity == Vector3.zero)
        {
            arrow.SetActive(true);
        }
    }
}
