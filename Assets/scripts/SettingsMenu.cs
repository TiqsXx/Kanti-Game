using UnityEngine;
using UnityEngine.Audio; //Importiert die AudioMixers
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //Erstellt eine Referenz für den Audiomixer
    public Slider VolumeSlider;
    public Dropdown QualityDropdown;


    void Update()
    {
        float savedVol = PlayerPrefs.GetFloat("VolumeSliderValue", 0.5f); //Hier wird der Speicher ausgelesen
        int savedQua = PlayerPrefs.GetInt("QualityIndex", 3);
        VolumeSlider.value = savedVol; //Hier wird der Wert der Variable ausgelesen und gesetzt
        if (audioMixer != null) { audioMixer.SetFloat("MasterVolume", savedVol); }
        if (QualityDropdown != null) { QualityDropdown.value = savedQua; }
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeSliderValue", volume); //Speichert die Variable in eine Spielereinstellung
        PlayerPrefs.Save(); //Stellt sicher, dass gespeichert wird
        audioMixer.SetFloat("MasterVolume", volume); //Setzt den Master-Input auf den eingestellten Wert des Sliders an, der von Unity mitgegeben wird.
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        PlayerPrefs.Save();
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ShowStartScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
