using UnityEngine;

public class HealthBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private int recoveryAmount;
    
    private HealthController _playerHealth;
    private void Awake()
    {
        _playerHealth = GameObject.FindGameObjectWithTag(TagManager.PlayerTag).GetComponent<HealthController>();
    }
    public void Execute()
    {
        _playerHealth.RestoreHealth(recoveryAmount);
    }
}
