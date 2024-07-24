using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private BulletController magicBallPrefab;
    [Space]
    [SerializeField] private float bulletForce;
    [SerializeField] private int damage;
    [SerializeField] private Transform attackPoint;

    public void Attack()
    {
        var instanstiatedBullet = Instantiate(magicBallPrefab.gameObject, attackPoint.position, Quaternion.identity);

        instanstiatedBullet.GetComponent<BulletController>().BulletDamage = damage;
        instanstiatedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce * Time.deltaTime);
    }
    //private IEnumerator AttackWithDelay()
    //{
    //    var instanstiatedBullet = Instantiate(magicBallPrefab.gameObject, attackPoint.position, Quaternion.identity);

    //    instanstiatedBullet.GetComponent<BulletController>().BulletDamage = damage;
    //    instanstiatedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * Time.deltaTime);

    //    yield return new WaitForSeconds(attackFrequency);

    //    Destroy(instanstiatedBullet);
    //}
}
