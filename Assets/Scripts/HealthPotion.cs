using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int healAmount = 20; // Сколько HP восстанавливает
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioMixer masterMixer; // Главный микшер
    private AudioSource audioSource;
    private void Awake()
    {
        // Создаем временный AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; // 2D звук

        // Назначаем выход на мастер-микшер
        if (masterMixer != null)
        {
            audioSource.outputAudioMixerGroup = masterMixer.FindMatchingGroups("Master")[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayPickupSound();
        other.GetComponent<Healthcontrol>().Heal(healAmount);
        Destroy(gameObject, 0.1f); // Задержка для звука
    }

    private void PlayPickupSound()
    {
        if (pickupSound == null)
        {
            Debug.LogWarning("Не назначен звук подбора!", gameObject);
            return;
        }

        // Воспроизводим через настроенный AudioSource
        audioSource.PlayOneShot(pickupSound);
    }
}
