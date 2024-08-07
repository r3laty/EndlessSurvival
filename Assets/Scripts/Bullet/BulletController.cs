using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [HideInInspector] public int BulletDamage = 0;
    
    [SerializeField] private float timeToDestroy;
    [SerializeField] private string enemyCompareTag;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyCompareTag))
        {
            collision.gameObject.TryGetComponent<HealthController>(out HealthController healthController);
           
            if (healthController != null)
            {
                healthController.DealDamage(BulletDamage);
            }
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyAfterTime());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyCompareTag))
        {
            other.TryGetComponent<HealthController>(out HealthController healthController);

            if (healthController != null)
            {
                healthController.DealDamage(BulletDamage);
            }
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyAfterTime());
        }
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSecondsRealtime(timeToDestroy);
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        StopCoroutine(DestroyAfterTime());
    }
}