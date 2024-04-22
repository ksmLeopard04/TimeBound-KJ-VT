using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct SettingsData
{
    public float masterVolume;
    public float SFXvolume;
    public float ambientVolume;
    public float lastMasterVolume;
    public float lastSFXvolume;
    public float lastAmbientVolume;
}