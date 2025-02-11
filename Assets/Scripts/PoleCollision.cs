using UnityEngine;

public class PoleCollision : MonoBehaviour
{
    Flag flag;
    private void Start()
    {
        flag = gameObject.GetComponentInParent<Flag>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolfBall")
        {
            flag.Victory();
        }
    }
}
