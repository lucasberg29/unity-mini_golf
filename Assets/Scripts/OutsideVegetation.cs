using NUnit.Framework;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class OutsideVegetation : MonoBehaviour
{
    private GameObject level;

    public LayerMask floorLayer;

    public List<GameObject> trees = new List<GameObject>();

    public int numberOfTrees;
    public float width;

    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Level");

        CreateVegetation();
    }

    private void CreateVegetation()
    {
        MeshRenderer floorMeshRenderer = level.GetComponent<MeshRenderer>();

        float xMin = floorMeshRenderer.bounds.min.x; // -17
        float zMin = floorMeshRenderer.bounds.min.z; // - 36

        float xMax = floorMeshRenderer.bounds.max.x; // 11
        float zMax = floorMeshRenderer.bounds.max.z; // 7


        float absXMin = xMin - width;
        float absZMin = zMin - width;
        
        float absXMax = xMax + width;
        float absZMax = zMax + width;

        for (uint i = 0; i <= numberOfTrees; i++)
        {
            float randomXPosition = 0.0f;
            float randomZPosition = 0.0f;
            do
            {
                randomXPosition = Random.Range(absXMin, absXMax);
                randomZPosition = Random.Range(absZMin, absZMax);
            }
            while ((randomXPosition > xMin && randomXPosition < xMax)
            && ((randomZPosition > zMin && randomZPosition < zMax)));

            Vector3 randomPosition = new Vector3(randomXPosition, 0.5f, randomZPosition);

            Quaternion randomYRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            GameObject randomTree = trees[Random.Range(0, trees.Count)];

            Instantiate(randomTree, randomPosition, randomYRotation);
        }

    }
}
