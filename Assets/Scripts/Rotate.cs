using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeTorque(rotationSpeed, ForceMode.Impulse);
    }

    void Update()
    {
    }
}
