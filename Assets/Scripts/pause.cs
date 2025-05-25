using UnityEngine;

public class pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool isPaused = false;
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
}
