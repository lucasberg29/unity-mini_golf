using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelUi : MonoBehaviour
{
    public GameObject maxStars;
    public GameObject pauseMenu;

    private bool isGamePaused;

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
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void RetryLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
