using UnityEngine;
using UnityEngine.UI; // For UI Text (or use TMPro)
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Congratulations : MonoBehaviour
{
    [Header("UI Settings")]
    public Text victoryText; // Use 'TMP_Text' for TextMeshPro
    public float messageDelay = 1f; // Optional delay

    public int totalEnemies;
    private int enemiesRemaining;
    public GameOvER Manager;

    void Start()
    {
        // Find all enemies with the "Enemy" tag (adjust if needed)
        enemiesRemaining = totalEnemies;

    }

    // Call this when an enemy dies
    public void OnEnemyDestroyed()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
            ShowVictoryMessage();
    }

    private void ShowVictoryMessage()
    {
        if (Manager != null)
        {
            Debug.Log("Calling gameOver()...");
            Manager.gameOver();  // Ensure this is called
        }
    }
}