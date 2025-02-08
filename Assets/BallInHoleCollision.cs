using UnityEngine;

public class BallInHoleCollision : MonoBehaviour
{
    Flag flag;

    private void Start()
    {
        flag = gameObject.GetComponentInParent<Flag>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        flag.Victory();
    }
}
