using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer masterMixer; // Assign your main Audio Mixer

    [Header("UI Slider")]
    public Slider volumeSlider;    // Assign your UI Slider

    private const string MIXER_PARAM = "MasterVolume";
    private const string PREFS_KEY = "MasterVol";

    void Start()
    {
        // Load saved volume (default: 75% if first time)
        float savedVolume = PlayerPrefs.GetFloat(PREFS_KEY, 0.75f);
        
        // Set initial values
        SetVolume(savedVolume);
        volumeSlider.value = savedVolume;
        
        // Setup slider event
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // Convert 0-1 slider to -80dB to 0dB scale
        float volumeDB = Mathf.Log10(sliderValue) * 20;
        if (sliderValue <= 0.0001f) volumeDB = -80f; // Mute at 0

        // Apply to mixer and save
        masterMixer.SetFloat(MIXER_PARAM, volumeDB);
        PlayerPrefs.SetFloat(PREFS_KEY, sliderValue);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save(); // Ensure settings persist
    }
}