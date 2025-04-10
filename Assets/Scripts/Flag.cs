using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    CapsuleCollider boxCollider;
    AudioSource victorySound;

    private GameObject musicManager;

    public Vector3 flagExternalAcceleration;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        Cloth flagCloth = GetComponentInChildren<Cloth>();
        flagCloth.externalAcceleration = flagExternalAcceleration;
    }

    public void Victory()
    {
        string sceneIndex = SceneManager.GetActiveScene().name;

        if (sceneIndex == "Level1")
        {
            SceneManager.LoadScene("Level2");
            musicManager.GetComponent<MusicManager>().PlayNextSong(2);
        }
        else if (sceneIndex == "Level2")
        {
            SceneManager.LoadScene("Level3");
            musicManager.GetComponent<MusicManager>().PlayNextSong(3);
        }
        else if (sceneIndex == "Level3")
        {
            SceneManager.LoadScene(0);
            musicManager.GetComponent<MusicManager>().PlayNextSong(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolfBall")
        {
            Victory();
        }
    }
}
