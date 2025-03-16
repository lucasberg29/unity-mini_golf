using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject levelUi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelUi = GameObject.FindGameObjectWithTag("LevelUi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
