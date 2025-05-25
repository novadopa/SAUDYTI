using UnityEngine;
using UnityEngine.Audio;

public class XpOrb : MonoBehaviour
{
    public int value = 50;

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
        other.GetComponent<Player>().AddXP(value);
        Destroy(gameObject, 0.1f); 
    }

    private void PlayPickupSound()
    {
        if (pickupSound == null)
        {
            Debug.LogWarning("Не назначен звук подбора!", gameObject);
            return;
        }

        audioSource.PlayOneShot(pickupSound);
    }
}