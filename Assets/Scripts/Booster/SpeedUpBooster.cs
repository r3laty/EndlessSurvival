using UnityEngine;

public class SpeedUpBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private float recoveryAmount;
    [SerializeField] private float timeOfBoost = 4.5f;

    private Movement _movement;
    private void Awake()
    {
        _movement = GameObject.FindWithTag(TagManager.PlayerTag).GetComponent<Movement>();
    }
    public void Execute()
    {
        StartCoroutine(_movement.IncreaseSpeed(timeOfBoost, recoveryAmount));
    }

    public string GetName()
    {
        return "Speed up";
    }

    public float GetDuration()
    {
        return timeOfBoost;
    }
}
