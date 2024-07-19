using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Shooting playerShooting;

    private Vector2 _movingVector;
    private bool _dashButton;
    private bool _shootButton;
    private bool _rechargingButton;
    private void Update()
    {
        playerMovement.SetMovingVector(_movingVector);
        playerMovement.SetDashBool(_dashButton);

        playerShooting.SetShootButton(_shootButton);
        playerShooting.SetRechargingButton(_rechargingButton);
    }
    public void OnMoving(InputAction.CallbackContext context)
    {
        _movingVector = context.ReadValue<Vector2>();
    }
    public void OnDashing(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _dashButton = context.ReadValue<float>() > 0.5f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _dashButton = false;
        }
    }
    public void OnShooting(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _shootButton = context.ReadValue<float>() > 0.5f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _shootButton = false;
        }
    }
    public void OnRecharging(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _rechargingButton = context.ReadValue<float>() > 0.5f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _rechargingButton = false;
        }
    }
}
