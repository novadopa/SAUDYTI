using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public int coins { get; private set; }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log($"[COINS] Coins updated: {coins}");
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0;

        if (soundMixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = soundMixerGroup;
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log($"[XP] Gained {amount} XP. Current XP: {currentXP}/{xpToNextLevel}");

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentXP -= xpToNextLevel;
        int oldXPToNextLevel = xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f);

        Debug.Log($"[LEVEL UP] Reached Level {currentLevel}!");
        Debug.Log($"[LEVEL UP] XP reset to {currentXP}. XP required for next level: {oldXPToNextLevel} → {xpToNextLevel}");

        PlayLevelUpSound();
    }

    private void PlayLevelUpSound()
    {
        if (levelUpSound == null)
        {
            Debug.LogWarning("[AUDIO] Level up sound not assigned!", this);
            return;
        }

        audioSource.PlayOneShot(levelUpSound, volume);
        Debug.Log("[AUDIO] Played level up sound.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("[INPUT] 'T' pressed — adding 50 XP.");
            AddXP(50);
        }
    }
}
