using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [HideInInspector] public int BulletDamage = 0;
    
    [SerializeField] private float timeToDestroy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
    private IEnumerator DestroyAfterTime()
    {
        Debug.Log($"Damage: {BulletDamage}");
        yield return new WaitForSecondsRealtime(timeToDestroy);
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        StopCoroutine(DestroyAfterTime());
    }
}