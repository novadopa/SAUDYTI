using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    public static PlayerNameManager Instance;

    [Header("UI References")]
    public TMP_Text greetingText; 
    public TMP_InputField nameInputField; 
    public Button saveNameButton; 

    private const string PLAYER_NAME_KEY = "PlayerName";

    void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

      
        LoadPlayerName();
    }

    void Start()
    {
  
        saveNameButton.onClick.AddListener(SavePlayerName);
    }

    public void LoadPlayerName()
    {
        string savedName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "Player");
        UpdateGreetingText(savedName);

   
        if (nameInputField != null)
            nameInputField.text = savedName;
    }

    public void SavePlayerName()
    {
        string newName = nameInputField.text;

  
        if (string.IsNullOrWhiteSpace(newName))
            newName = "Player";

        PlayerPrefs.SetString(PLAYER_NAME_KEY, newName);
        PlayerPrefs.Save();

        UpdateGreetingText(newName);
    }

    void UpdateGreetingText(string name)
    {
        if (greetingText != null)
            greetingText.text = $"Hello, {name}!";
    }
}