using UnityEngine;

public class GhostCollider : MonoBehaviour
{
    private Animator ghostAnimator;

    public bool isAnimating;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAnimating = false;
        ghostAnimator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating)
        {
            transform.LookAt(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
            isAnimating = true;
            player = other.gameObject;
            ghostAnimator.SetBool("playerSpotted", true);
        }
    }
}
