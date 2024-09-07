using FMODUnityResonance;
using UnityEngine;

public class GrenadeLauncher : BaseGun
{
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float launchForce = 700f;
    public void SetShootButton(bool shotButton)
    {
        _shootButton = shotButton;
    }
    public void SetRechargingButton(bool rechargingButton)
    {
        _rechargingButton = rechargingButton;
    }
    private void Update()
    {
        BulletsCountChanged?.Invoke(_currentBulletCount);

        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            _currentBulletCount = 0;
            StartCoroutine(Recharging());
        }
    }
    protected override void Shoot()
    {
        base.Shoot();

        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentBulletCount > 0)
            {
                PlayShootSound();

                GameObject grenade = Instantiate(grenadePrefab.gameObject, shotPoint.position, Quaternion.identity);
                Grenade bazeGrenade = grenade.GetComponent<Grenade>();
                bazeGrenade.BulletDamage = bulletDamage;
                Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();

                grenadeRb.AddForce(transform.forward * launchForce * Time.deltaTime);
                _currentBulletCount--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (_currentBulletCount <= 0)
            {
                StartCoroutine(Recharging());
            }
        }
    }
}
