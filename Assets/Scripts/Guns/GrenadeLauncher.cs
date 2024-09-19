using FMODUnityResonance;
using UnityEngine;

public class GrenadeLauncher : BaseGun
{
    public Grenade CurrentGrenade = null;
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

                Grenade baseGrenade = grenade.GetComponent<Grenade>();
                baseGrenade.BulletDamage = bulletDamage;
                CurrentGrenade = baseGrenade;

                Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
                grenadeRb.AddForce(transform.forward * launchForce * Time.deltaTime);
                CurrentBulletRb = grenadeRb;

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
