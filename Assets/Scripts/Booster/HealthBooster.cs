using UnityEngine;

public class HealthBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private int recoveryAmount;

    private HealthController _playerHealth;

    private void Awake()
    {
        _playerHealth = GameObject.FindWithTag(TagManager.PlayerTag).GetComponent<HealthController>();
    }
    public void Execute()
    {
        _playerHealth.RestoreHealth(recoveryAmount);
    }

    public string GetName()
    {
        return "Health";
    }

    public float GetDuration()
    {
        return 0;
    }
}
