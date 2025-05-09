using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvER : MonoBehaviour
{
    public GameObject gameOverUI;
    public void gameOver()
    {
        Debug.Log("Game Over Triggered!");
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
