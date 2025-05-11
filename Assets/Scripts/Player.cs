using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int coins { get; private set; }
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log($"Coins: {coins}");
    }
    [Header("Sound Settings")]
    [SerializeField] private AudioClip levelUpSound;
    [SerializeField] private AudioMixerGroup soundMixerGroup;
    [Range(0f, 1f)] public float volume = 0.7f;

    [Header("XP Settings")]
    public int currentXP = 0;
    public int xpToNextLevel = 100;
    public int currentLevel = 1;

    private AudioSource audioSource;

    private void Awake()
    {
        // Настройка AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; // 2D звук

        if (soundMixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = soundMixerGroup;
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f); // Увеличиваем требование

        PlayLevelUpSound();
        // Здесь можно добавить другие эффекты уровня (визуальные и т.д.)
    }

    private void PlayLevelUpSound()
    {
        if (levelUpSound == null)
        {
            Debug.LogWarning("Level up sound not assigned!", this);
            return;
        }

        // Вариант 1: Через существующий AudioSource
        audioSource.PlayOneShot(levelUpSound, volume);

        // Вариант 2: Через камеру (если объект может быть уничтожен)
        // AudioSource.PlayClipAtPoint(levelUpSound, 
        //     Camera.main.transform.position, 
        //     volume);
    }

    // Для тестирования (можно удалить в финальной версии)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddXP(50); // Тестовое добавление XP
        }
    }
}
