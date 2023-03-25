using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour

{
    private Dictionary<int, List<int>> _resolutions = new Dictionary<int, List<int>>();
    private int _selectedResolution;
    //video options
    public Toggle FullscreenToggle;
    public TextMeshProUGUI ResolutionText;
    //audio options
    public Slider MusicVolumeSlider;
    public Slider SoundEffectsVolumeSlider;
    //audio sources
    public AudioSource MainMenuMusic;
    public AudioSource ButtonClickedSoundEffect;
    // Menu panels
    public GameObject MainMenuPanel;
    public GameObject OptionsMenuPanel;

    void Start()
    {
        SetUpResolutionOptions();
        _selectedResolution = PlayerPrefs.GetInt("SelectedResolution", 1);
        _UpdateResolutionText();
        FullscreenToggle.isOn = bool.Parse(PlayerPrefs.GetString("FullscreenOn", "true"));
        MainMenuMusic.volume = MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        ButtonClickedSoundEffect.volume = SoundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 0.5f);
    }

    private void _UpdateResolutionText()
    {
        ResolutionText.text = _resolutions[_selectedResolution][0].ToString() + "x" + _resolutions[_selectedResolution][1].ToString();
    }

    private void SetUpResolutionOptions()
    {
        _resolutions.Add(0, new List<int> { 1280, 720 });
        _resolutions.Add(1, new List<int> { 1920, 1080 });
        _resolutions.Add(2, new List<int> { 2560, 1440 });
        _resolutions.Add(3, new List<int> { 3840, 2160 });
    }
    //sound effect functions
    private void _PlayButtonClickedSoundEffect()
    {
        ButtonClickedSoundEffect.Play();
    }
    //main menu functions
    public void StartButtonClicked()
    {
        _PlayButtonClickedSoundEffect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void OptionsButtonClicked()
    {
        _PlayButtonClickedSoundEffect();
        MainMenuPanel.SetActive(false);
        OptionsMenuPanel.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        _PlayButtonClickedSoundEffect();
        Application.Quit();
    }

    //options menu functions
    public void BackButtonClicked()
    {
        _PlayButtonClickedSoundEffect();
        OptionsMenuPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    //video options
    private void _ApplyVideoOptions()
    {
        Screen.SetResolution(_resolutions[_selectedResolution][0], _resolutions[_selectedResolution][1], FullscreenToggle.isOn);
    }

    public void ResolutionsButtonRightClicked()
    {
        _PlayButtonClickedSoundEffect();
        if(_selectedResolution < 3)
        {
            PlayerPrefs.SetInt("SelectedResolution", ++_selectedResolution);
            _UpdateResolutionText();
            _ApplyVideoOptions();
        }
    }

    public void ResolutionsButtonLeftClicked()
    {
        _PlayButtonClickedSoundEffect();
        if(_selectedResolution > 0)
        {
            PlayerPrefs.SetInt("SelectedResolution", --_selectedResolution);
            _UpdateResolutionText();
            _ApplyVideoOptions();
        }
    }

    public void FullscreenToggleClicked()
    {
        _PlayButtonClickedSoundEffect();
        PlayerPrefs.SetString("FullscreenOn", FullscreenToggle.isOn.ToString());
        _ApplyVideoOptions();
    }
    //audio options

    public void MusicVolumeAdjusted()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeSlider.value);
        MainMenuMusic.volume = MusicVolumeSlider.value;
    }

    public void SoundEffectsVolumeAdjusted()
    {
        PlayerPrefs.SetFloat("SoundEffectsVolume", SoundEffectsVolumeSlider.value);
        ButtonClickedSoundEffect.volume = SoundEffectsVolumeSlider.value;
    }
}
