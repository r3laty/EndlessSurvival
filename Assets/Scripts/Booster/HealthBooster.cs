using UnityEngine;

public class HealthBooster : MonoBehaviour, IBoostable
{
    [SerializeField] private int recoveryAmount;
    public void Execute()
    {
        Debug.Log($"recovery hp {recoveryAmount}");
    }
}
