using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int healAmount = 20; 
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioMixer masterMixer; 
    private AudioSource audioSource;
    private void Awake()
    {
       
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; 

     
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
        Destroy(gameObject, 0.1f); 
    }

    private void PlayPickupSound()
    {
        if (pickupSound == null)
        {
            Debug.LogWarning("Nepaskirtas objektas!", gameObject);
            return;
        }

        audioSource.PlayOneShot(pickupSound);
    }
}
