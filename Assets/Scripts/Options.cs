using UnityEngine;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    public GameObject optionsPanel; // Drag your options panel here

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Check if player presses Esc
        { 
            SceneManager.LoadScene("Main Menu");
        }
    }
}
