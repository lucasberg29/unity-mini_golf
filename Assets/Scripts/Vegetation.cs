using UnityEngine;

public class Vegetation : MonoBehaviour
{
    public int seed;

    public GameObject [] plants;

    void Start()
    {
        Random.InitState(seed); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
