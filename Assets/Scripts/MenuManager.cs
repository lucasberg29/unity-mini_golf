using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject musicManager;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("MusicManager") == null)
        {
            Instantiate(musicManager);
        }

        Scene sceneManager = SceneManager.GetActiveScene();
        if (sceneManager.name != "Menu")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
