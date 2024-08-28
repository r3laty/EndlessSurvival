using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider shotSoundSlider;
    [SerializeField] private Slider boostSoundSlider;
    private void Start()
    {
        shotSoundSlider.onValueChanged.AddListener(SetShotVolume);
        boostSoundSlider.onValueChanged.AddListener(SetBoostVolume);
    }
    private void Update()
    {
        if (Saves.Instance != null && AudioManager.Instance != null)
        {
            Saves.Instance.LoadFromFile(AudioManager.Instance.ShotVolume, AudioManager.Instance.BoosterVolume);

            Debug.Log($"Shot sound volume {AudioManager.Instance.ShotVolume}");
            Debug.Log($"Booster sound volume {AudioManager.Instance.BoosterVolume}");

            shotSoundSlider.value = AudioManager.Instance.ShotVolume;
            boostSoundSlider.value = AudioManager.Instance.BoosterVolume;
        }
    }
    private void SetShotVolume(float value)
    {
        if (Saves.Instance != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.ShotVolume = value;
            Saves.Instance.SaveVolume(AudioManager.Instance.ShotVolume, AudioManager.Instance.BoosterVolume);
        }

    }

    private void SetBoostVolume(float value)
    {
        if (Saves.Instance != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.BoosterVolume = value;
            Saves.Instance.SaveVolume(AudioManager.Instance.ShotVolume, AudioManager.Instance.BoosterVolume);
        }
    }
}
