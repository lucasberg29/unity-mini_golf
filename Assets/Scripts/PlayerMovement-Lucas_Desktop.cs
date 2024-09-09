using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;
    public float ballSpeed = 0.0f;

    public GameObject arrow;

    public AudioSource ballHit;

    public Rigidbody golfBall;
    public Transform ballPosition;
    public Transform cameraTransform;
    public BallForce stroke;
    public BallForce force;

    public Vector3 velocity;
    Vector3 placeToLookAt = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (controller.isGrounded)
        {
            velocity.y = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) +
                       (transform.forward * z);
        controller.Move(move * speed * Time.deltaTime);

        //if(controller.isGrounded)
        //{
        //    velocity.y = 0.0f;
        //}

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    ballSpeed += Time.deltaTime;
        //}

        //if(Input.GetButton("Jump"))
        //{
        //    ballSpeed += Time.deltaTime * 10.0f;
        //    force.SetForce((int)ballSpeed);
        //    Vector3 playerToBall = ballPosition.position - transform.position;
        //    playerToBall *= 2;
        //    placeToLookAt = new Vector3(playerToBall.x,0,playerToBall.z);
        //}


        //if (Input.GetButtonUp("Jump"))
        //{
        //    ballHit.Play();
        //    arrow.SetActive(false);
        //    golfBall.velocity = new 
        //    Vector3( placeToLookAt.x * (ballSpeed /10), 0, placeToLookAt.z * (ballSpeed / 10));

        //    ballSpeed = 0.0f;
        //    stroke.AddStroke();
        //}
        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
