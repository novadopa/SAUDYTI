using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool isPaused = false; // Глобальная переменная для проверки паузы

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
                Resume();
            else
                Pause();
        }
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Home()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
