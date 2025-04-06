using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvER : MonoBehaviour
{
    public GameObject gameOverUI;
    public void gameOver()
    {
        Debug.Log("Game Over Triggered!");
        gameOverUI.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
