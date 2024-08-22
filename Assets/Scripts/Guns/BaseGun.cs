using FMODUnity;
using System.Collections;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [SerializeField] protected int bulletsCount;
    [SerializeField] protected float delayBetweenShots;
    [SerializeField] protected float rechargingTime;
    [SerializeField] protected EventReference shotSound;

    protected bool _shootButton;
    protected bool _rechargingButton;
    protected int _currentBulletCount;
    protected bool _recharging;
    protected bool _shootDelay;

    private void Start()
    {
        _currentBulletCount = bulletsCount;
    }

    protected virtual void Shoot()
    {

    }
    protected virtual void PlayShootSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShot(shotSound, this.transform.position);
        }
    }

    protected IEnumerator DelayBetweenShots()
    {
        Debug.Log("DelayBetweenShots coroutine works!");
        _shootDelay = true;
        yield return new WaitForSeconds(delayBetweenShots);

        _shootDelay = false;
    }
    protected IEnumerator Recharging()
    {
        Debug.Log($"Recharging coroutine works!" +
            $"\nrecharging time {rechargingTime}");
        _currentBulletCount = 0;
        _recharging = true;
        yield return new WaitForSeconds(rechargingTime);
        Debug.Log($"Recharging coroutine was end!");
        _currentBulletCount = bulletsCount;
        _recharging = false;
    }
}
