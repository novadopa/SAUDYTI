using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congratulations : MonoBehaviour
{
    [Header("UI Settings")]
    public Text victoryText; // Jei naudojate TextMeshPro, pakeiskite į TMP_Text
    public float messageDelay = 1f;

    [Header("Game Settings")]
    public GameOvER Manager; // Įsitikinkite, kad šis objektas yra priskirtas Unity Editor

    private int enemiesRemaining;

    void Start()
    {
        UpdateEnemyCount(); // Atnaujinti priešų skaičių starte
    }

    // Šis metodas turi būti iškviestas kiekvieną kartą, kai priešas žūva
    public void OnEnemyDestroyed()
    {
        enemiesRemaining--; // Sumažinti likusių priešų skaičių
        Debug.Log($"Priešas sunaikintas! Liko: {enemiesRemaining}");


        if (enemiesRemaining <= 0)
        {
            ShowVictoryMessage();
        }
    }

    // Galima naudoti, jei priešai dinamiškai atsiranda/dingsta
    public void UpdateEnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRemaining = enemies.Length;
        Debug.Log($"Viso priešų: {enemiesRemaining}");
    }

    private void ShowVictoryMessage()
    {
        // Dar kartą patikriname, ar tikrai nebėra priešų
        UpdateEnemyCount();

        if (enemiesRemaining <= 1)
        {
            Debug.Log("Lygis įveiktas! Iškviečiamas gameOver()...");
            Manager.gameOver(); // Perjungti į pergalės ekraną

        }
    }
}