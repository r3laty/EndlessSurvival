using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [Space]
    [SerializeField] private Transform shotPoint;
    [Space]
    [SerializeField] private float delayBetweenShots;
    [SerializeField] private float rechargingTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletsCount;

    private bool _shootButton;
    private bool _rechargingButton;

    private bool _shootDelay;
    private bool _recharging;
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
        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            bulletsCount = 0;
            StartCoroutine(Recharging());
        }
    }
    private void Shoot()
    {
        if (!_recharging || _rechargingButton)
        {


            if (!_shootDelay && bulletsCount > 0)
            {
                GameObject bullet = Instantiate(bulletPrefab.gameObject, shotPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * Time.deltaTime);

                bulletsCount--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (bulletsCount <= 0 )
            {
                StartCoroutine(Recharging());
            }
        }
    }
    private IEnumerator DelayBetweenShots()
    {
        _shootDelay = true;
        yield return new WaitForSeconds(delayBetweenShots);

        _shootDelay = false;
    }
    private IEnumerator Recharging()
    {
        _recharging = true;
        
        yield return new WaitForSeconds(rechargingTime);

        bulletsCount = 10;
        _recharging = false;
    }
}