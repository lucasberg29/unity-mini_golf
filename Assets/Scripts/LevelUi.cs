using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelUi : MonoBehaviour
{
    public GameObject maxStars;
    public GameObject pauseMenu;

    private bool isGamePaused;

    private void Start()
    {
        GameObject fontManager = GameObject.FindGameObjectWithTag("FontManager");
        if (fontManager != null)
        {
            fontManager.GetComponent<FontManager>().GetTextsFromScene();
        }

        isGamePaused = false;
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
        }
    }

    public void MaxForce()
    {
        maxStars.GetComponent<Animator>().SetBool("isAnimating", true);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Cursor.visible = false;
    }

    public void RetryLevel()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().PlayNextSong(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
