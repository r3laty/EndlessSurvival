using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider shotSoundSlider;
    [SerializeField] private Slider boostSoundSlider;


    private void Update()
    {
        AudioManager.Instance.ShotVolume = shotSoundSlider.value;
        AudioManager.Instance.BoosterVolume = boostSoundSlider.value;
    }
}
