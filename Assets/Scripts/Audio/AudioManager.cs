using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0, 1)]public float MasterVolume = 1;
    [Range(0, 1)]public float ShotVolume = 1;
    [Range(0, 1)]public float BoosterVolume = 1;

    private Bus _masterBus;
    private Bus _shotSoundBus;
    private Bus _boosterSoundBus;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _masterBus = RuntimeManager.GetBus("bus:/");
        _shotSoundBus = RuntimeManager.GetBus("bus:/Shot");
        _boosterSoundBus = RuntimeManager.GetBus("bus:/Booster");
    }
    private void Update()
    {
        _masterBus.setVolume(MasterVolume);
        _shotSoundBus.setVolume(ShotVolume);
        _boosterSoundBus.setVolume(BoosterVolume);
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
