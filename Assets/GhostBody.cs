using UnityEngine;

public class GhostBody : MonoBehaviour
{
    public GhostCollider ghostCollision;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostCollision.isAnimating)
        {
            transform.LookAt(player.transform.position);
        }
    }
}
