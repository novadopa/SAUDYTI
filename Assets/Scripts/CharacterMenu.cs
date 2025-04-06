using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image characterPreviewUI;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject menuPanel; // The entire menu panel

    [Header("Settings")]
    [SerializeField] private string characterFolder = "Characters";
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private KeyCode exitKey = KeyCode.Escape;
    [SerializeField] private bool startVisible = true;

    private Sprite[] allSprites;
    private int currentIndex = 0;

    void Start()
    {
        // Initialize menu visibility
        if (menuPanel != null)
        {
            menuPanel.SetActive(startVisible);
        }

        // Load all character sprites
        allSprites = Resources.LoadAll<Sprite>(characterFolder);

        if (allSprites == null || allSprites.Length == 0)
        {
            Debug.LogError($"No sprites found in Resources/{characterFolder}");
            return;
        }

        // Load saved selection
        LoadSavedCharacter();

        // Setup play button
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }
    }

    void Update()
    {
        // Close menu when ESC is pressed and menu is active
        if (menuPanel != null && menuPanel.activeSelf && Input.GetKeyDown(exitKey))
        {
            CloseMenu();
        }
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % allSprites.Length;
        UpdateCharacterPreview();
        SaveSelection();
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + allSprites.Length) % allSprites.Length;
        UpdateCharacterPreview();
        SaveSelection();
    }

    public void OpenMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
            LoadSavedCharacter();
        }
    }

    public void CloseMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    private void LoadSavedCharacter()
    {
        string savedSpriteName = PlayerPrefs.GetString("SelectedCharacter", allSprites[0].name);
        for (int i = 0; i < allSprites.Length; i++)
        {
            if (allSprites[i].name == savedSpriteName)
            {
                currentIndex = i;
                break;
            }
        }
        UpdateCharacterPreview();
    }

    private void UpdateCharacterPreview()
    {
        if (characterPreviewUI != null && allSprites != null)
        {
            characterPreviewUI.sprite = allSprites[currentIndex];
        }
    }

    private void SaveSelection()
    {
        PlayerPrefs.SetString("SelectedCharacter", allSprites[currentIndex].name);
        PlayerPrefs.Save();
    }

    private void StartGame()
    {
        SaveSelection();
        SceneManager.LoadScene(gameSceneName);
    }
}