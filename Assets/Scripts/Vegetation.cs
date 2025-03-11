using UnityEngine;
using UnityEngine.UIElements;

public class Vegetation : MonoBehaviour
{
    public int seed;

    public GameObject [] plants;

    private GameObject floor;

    public uint numberOfPlants;

    public LayerMask floorLayer;
    public float raycastHeight = 10.0f;

    void Start()
    {
        Random.InitState(seed);

        floor = GameObject.FindGameObjectWithTag("Floor");

        GenerateVegetation();
    }



    // Update is called once per frame
    void Update()
    {

    }

    void GenerateVegetation()
    {
        MeshRenderer floorMeshRenderer = floor.GetComponent<MeshRenderer>();

        float xMin = floorMeshRenderer.bounds.min.x;
        float zMin = floorMeshRenderer.bounds.min.z;

        float xMax = floorMeshRenderer.bounds.max.x;
        float zMax = floorMeshRenderer.bounds.max.z;

        float xStep = (xMax - xMin) / (float)numberOfPlants;
        float zStep = (zMax - zMin) / (float)numberOfPlants;

        for (uint i = 0; i <= numberOfPlants; i++)
        {
            for (uint j = 0; j <= numberOfPlants; j++)
            {
                float xPos = xMin + (i * xStep);
                float zPos = zMin + (j * zStep);

                Vector3 rayOrigin = new Vector3(xPos, floorMeshRenderer.bounds.max.y + raycastHeight, zPos);

                if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, Mathf.Infinity, floorLayer))
                {
                    if (hit.collider.gameObject.tag == "Floor")
                    {
                        Quaternion randomYRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

                        float xOffSet = Random.Range(0.0f, 10.0f);
                        
                        if (xOffSet + hit.point.x > xMax)
                        {
                            xOffSet *= -1.0f;
                        }

                        float zOffSet = Random.Range(0.0f, 10.0f);

                        if (zOffSet + hit.point.z > zMax)
                        {
                            zOffSet *= -1.0f;
                        }

                        Vector3 positionPlusOffset = new Vector3(hit.point.x + xOffSet, hit.point.y, hit.point.z + xOffSet);

                        Instantiate(plants[1], positionPlusOffset, randomYRotation);
                    }
                }
                else
                {
                    Debug.LogWarning("No floor hit at: " + rayOrigin);
                }
            }
        }
    }

}
