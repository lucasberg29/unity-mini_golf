using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    CapsuleCollider boxCollider;
    AudioSource victorySound;

    MusicManager manager;

    public void Victory()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolfBall")
        {
            Victory();
            string sceneIndex = SceneManager.GetActiveScene().name;

            if (sceneIndex == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (sceneIndex == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (sceneIndex == "Level3")
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
