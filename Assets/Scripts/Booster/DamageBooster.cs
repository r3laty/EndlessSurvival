using UnityEngine;

public class DamageBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private int recoveryAmount;
    [SerializeField] private float timeOfBoost = 4.5f;

    private Shooting _shooting;
    private void Awake()
    {
        _shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }
    public void Execute()
    {
        StartCoroutine(_shooting.IncreaseDamage(timeOfBoost, recoveryAmount));
    }
}
