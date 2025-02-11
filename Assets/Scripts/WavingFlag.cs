using UnityEngine;

public class WavingFlag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mesh clothMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        clothMesh.RecalculateNormals();
    }
}
