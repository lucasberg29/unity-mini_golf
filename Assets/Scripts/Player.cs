using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject levelUi;

    void Start()
    {
        levelUi = GameObject.FindGameObjectWithTag("LevelUi");
    }

    void Update()
    {
        
    }
}
