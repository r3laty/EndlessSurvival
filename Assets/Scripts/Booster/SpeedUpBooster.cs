using UnityEngine;

public class SpeedUpBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private float recoveryAmount;
    [SerializeField] private float timeOfBoost = 4.5f;

    private Movement _playerMovement;
    private void Awake()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    public void Execute()
    {
        StartCoroutine(_playerMovement.IncreaseSpeed(timeOfBoost, recoveryAmount));
    }
}
