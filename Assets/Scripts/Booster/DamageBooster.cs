using UnityEngine;

public class DamageBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private int recoveryAmount;
    [SerializeField] private float timeOfBoost = 4.5f;

    private BaseGun _shooting;
    private void Awake()
    {
        _shooting = GameObject.FindWithTag(TagManager.PlayerTag).GetComponent<BaseGun>();
    }
    public void Execute()
    {
        StartCoroutine(_shooting.IncreaseDamage(timeOfBoost, recoveryAmount));
    }

    public string GetName()
    {
        return "Damage";
    }

    public float GetDuration()
    {
        return timeOfBoost;
    }
}
