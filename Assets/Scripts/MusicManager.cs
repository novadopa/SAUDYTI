using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [Header("Music Tracks")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip level1Music;
    [SerializeField] private AudioClip level2Music;
    [SerializeField] private AudioClip level3Music;
    [SerializeField] private float fadeDuration = 1f;

    [Header("Scene Names")]
    [SerializeField] private string mainMenuScene = "Main Menu";
    [SerializeField] private string level1Scene = "Level 1";
    [SerializeField] private string level2Scene = "Level 2";
    [SerializeField] private string level3Scene = "Level 3";

    private AudioSource audioSource;
    private string currentSceneName;
    private static MusicManager _instance;

    void Awake()
    {
        // Singleton pattern
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (currentSceneName != scene.name)
        {
            currentSceneName = scene.name;
            HandleMusicTransition();
        }
    }

    private void HandleMusicTransition()
    {
        AudioClip targetClip = GetMusicForScene(currentSceneName);

        if (targetClip != null && targetClip != audioSource.clip)
        {
            StartCoroutine(FadeMusic(targetClip));
        }
    }

    private AudioClip GetMusicForScene(string sceneName)
    {
        if (sceneName == mainMenuScene) return mainMenuMusic;
        if (sceneName == level1Scene) return level1Music;
        if (sceneName == level2Scene) return level2Music;
        if (sceneName == level3Scene) return level3Music;

        // Fallback (plays level1 music for any unspecified scene)
        Debug.LogWarning($"No music defined for scene: {sceneName}. Using Level1 music.");
        return level1Music;
    }

    private System.Collections.IEnumerator FadeMusic(AudioClip newClip)
    {
        // Fade out
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}