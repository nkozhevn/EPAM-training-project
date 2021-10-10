using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Dropdown resolutionDropdown;
    private Resolution[] _resolutions;

    void Start()
    {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);

            if(_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    private void Back()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ResolutionDropdown(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QualityDropdown(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void VolumeSlider(float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }

    public void BackButton()
    {
        Back();
    }
}
