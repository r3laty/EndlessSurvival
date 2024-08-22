using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : BaseGun
{
    public int InitialBulletCount => _currentBulletCount;

    [SerializeField] private UnityEvent<int> BulletsCountChanged = new UnityEvent<int>();
    [Space]
    [SerializeField] private BulletController bulletPrefab;
    [Space]
    [SerializeField] private Transform shotPoint;
    [Space]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;

    private int _initialDamage;
    private void Start()
    {
        _initialDamage = bulletDamage;
        _currentBulletCount = bulletsCount;
    }
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
            StartCoroutine(Recharging());
            _rechargingButton = false;
        }
    }
    protected override void Shoot()
    {
        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentBulletCount > 0)
            {
                PlayShootSound();

                GameObject bullet = Instantiate(bulletPrefab.gameObject, shotPoint.position, Quaternion.identity);

                bullet.GetComponent<BulletController>().BulletDamage = bulletDamage;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * Time.deltaTime);

                _currentBulletCount--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (_currentBulletCount <= 0)
            {
                StartCoroutine(Recharging());
            }
        }
    }

    public IEnumerator IncreaseDamage(float timeOfBoost, int damageToBoost)
    {
        bulletDamage += damageToBoost;

        yield return new WaitForSeconds(timeOfBoost);

        bulletDamage = _initialDamage;
    }
    public void ResetBulletCound()
    {
        _currentBulletCount = bulletsCount;
    }
}