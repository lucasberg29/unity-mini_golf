using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level1");
        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().PlayNextSong(1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
