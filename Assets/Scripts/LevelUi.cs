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
        isGamePaused = false;
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
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
