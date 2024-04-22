using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Reflection;
using TMPro;
using System.Linq;

public class Settings : MonoBehaviour
{
    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider ambientSlider;
    [SerializeField] AudioMixer audioMixer;
    public static SettingsData mySettings;
    string filePath;
    const string RootPath = "SaveData\\";

    private void Start()
    {
        mySettings = new SettingsData();
        filePath = RootPath + "settingsData\\settings.dat";
        if (File.Exists("SaveData\\settingsData\\settings.dat"))
        {
            LoadSettings();
            masterSlider.value = mySettings.masterVolume;
            audioMixer.SetFloat("Master", Mathf.Log10(mySettings.masterVolume) * 20);
            SFXSlider.value = mySettings.SFXvolume;
            audioMixer.SetFloat("SFX", Mathf.Log10(mySettings.SFXvolume) * 20);
            ambientSlider.value = mySettings.ambientVolume;
            audioMixer.SetFloat("Ambient", Mathf.Log10(mySettings.ambientVolume) * 20);
        }
        else
        {
            mySettings.masterVolume = masterSlider.value = 1;
            mySettings.SFXvolume = SFXSlider.value = 1;
            mySettings.ambientVolume = ambientSlider.value = 1;
            SaveSettings();
        }
    }
    public void ChangeMasterVolume()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        SaveSettings();
    }
    public void ChangeSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        SaveSettings();
    }
    public void ChangeAmbientVolume()
    {
        float volume = ambientSlider.value;
        audioMixer.SetFloat("Ambient", Mathf.Log10(volume) * 20);
        SaveSettings();
    }
    public void SaveSettings()
    {
        mySettings.masterVolume = masterSlider.value;
        mySettings.SFXvolume = SFXSlider.value;
        mySettings.ambientVolume = ambientSlider.value;
        if (!Directory.Exists("SaveData\\settingsData"))
        {
            Directory.CreateDirectory("SaveData\\settingsData");
        }
        SaveManager.SaveData(filePath, ref mySettings);
    }
    public void LoadSettings()
    {
        SaveManager.LoadData(filePath, ref mySettings);
    }
}
