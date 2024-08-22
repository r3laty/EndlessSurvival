using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float maxDamage = 100f;
    [SerializeField] private float explosionForce = 700f;
    [SerializeField] private float timeToExplode;
    [SerializeField] private LayerMask layerMask;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.FloorTag))
        {
            Invoke("Explode", timeToExplode);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);

        foreach (Collider nearbyObject in colliders)
        {
            float distance = Vector3.Distance(transform.position, nearbyObject.transform.position);
            float damage = CalculateDamage(distance);

            if (nearbyObject.TryGetComponent<HealthController>(out HealthController targetHealth))
            {
                targetHealth.DealDamage((int)damage);
            }
        }

        Destroy(gameObject);
    }

    float CalculateDamage(float distance)
    {
        float damage = maxDamage * (1 - distance / explosionRadius);
        return Mathf.Max(0f, damage);
    }
}
