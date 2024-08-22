using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Fast")]
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Shooting playerShooting;
    [Header("Strong")]
    [SerializeField] private Movement player2Movement;
    [SerializeField] private Shooting player2Shooting;
    [SerializeField] private GrenadeLauncher player2Launcher;
    [Header("Normal")]
    [SerializeField] private Movement player3Movement;
    [SerializeField] private Shooting player3Shooting;
    [Space]
    [SerializeField] private PauseController pause;

    private Vector2 _movingVector;
    private bool _dashButton;
    private bool _shootButton;
    private bool _rechargingButton;
    private bool _pauseButton;
    private void Update()
    {
        if (playerMovement != null)
        {
            playerMovement.SetMovingVector(_movingVector);
            playerMovement.SetDashBool(_dashButton);
        }
        if (player2Movement != null)
        {
            player2Movement.SetMovingVector(_movingVector);
            player2Movement.SetDashBool(_dashButton);
        }
        if (player3Movement != null)
        {
            player3Movement.SetMovingVector(_movingVector);
            player3Movement.SetDashBool(_dashButton);
        }
        if (playerShooting != null)
        {
            playerShooting.SetShootButton(_shootButton);
            playerShooting.SetRechargingButton(_rechargingButton);
        }
        if (player2Shooting != null)
        {
            player2Shooting.SetShootButton(_shootButton);
            player2Shooting.SetRechargingButton(_rechargingButton);

            player2Launcher.SetShootButton(_shootButton);
            player2Launcher.SetRechargingButton(_rechargingButton);
        }
        if (player3Shooting != null)
        {
            player3Shooting.SetShootButton(_shootButton);
            player3Shooting.SetRechargingButton(_rechargingButton);
        }

        pause.SetPauseButton(_pauseButton);
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
    public void OnPausing(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _pauseButton = context.ReadValue<float>() > 0.5f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _pauseButton = false;
        }
    }
}
