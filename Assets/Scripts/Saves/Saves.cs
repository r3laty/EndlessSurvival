using System;
using System.IO;
using UnityEngine;

public class Saves : MonoBehaviour
{
    public static Saves Instance;

    
    [SerializeField] private string fileName = "settings.json";
    private string _savePath;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        SetSavePath();
    }
    public void SaveVolume(float shootSound, float boosterSound)
    {
        VolumeSettings volumeSettings = new VolumeSettings
        {
            ShotVolume = shootSound,
            BoosterVolume = boosterSound
        };

        string json = JsonUtility.ToJson(volumeSettings, true);

        try
        {
            File.WriteAllText(_savePath, json);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
        }
    }

    public void LoadFromFile(float shootSound, float boosterSound)
    {
        if (!File.Exists(_savePath))
        {
            Debug.Log($"File {fileName} does not exist");
            return;
        }

        string json = File.ReadAllText(_savePath);
        VolumeSettings volumeSettingsFromJson = JsonUtility.FromJson<VolumeSettings>(json);

        shootSound = volumeSettingsFromJson.ShotVolume;
        boosterSound = volumeSettingsFromJson.BoosterVolume;
    }
    private void SetSavePath()
    {
        _savePath = Path.Combine(Application.dataPath, fileName);
    }
}
