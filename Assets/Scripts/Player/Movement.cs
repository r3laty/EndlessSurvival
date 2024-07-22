using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    [Header("Walk")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 0.15f;
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private Vector2 _movingVector;
    private bool _isDashing;
    private float _dashCooldownTimer = 0f;
    private bool _dashButton;
    private float _initialSpeed;
    private void Start()
    {
        _initialSpeed = MoveSpeed;
    }
    public void SetMovingVector(Vector2 movingVector)
    {
        _movingVector = movingVector;
    }
    public void SetDashBool(bool dashButton)
    {
        _dashButton = dashButton;
    }
    private void Update()
    {
        if (_isDashing)
        {
            return;
        }

        _dashCooldownTimer -= Time.deltaTime;

        if (_movingVector != null && _dashCooldownTimer <= 0 && !_isDashing && _dashButton)
        {
            StartCoroutine(Dash());
        }
        else
        {
            MoveCharacter();
            StopAllCoroutines();
        }
    }
    private void MoveCharacter()
    {
        Vector3 movement = new Vector3(_movingVector.x * MoveSpeed * Time.deltaTime, 0, _movingVector.y * MoveSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);
        }

        transform.Translate(movement, Space.World);
    }
    private IEnumerator Dash()
    {
        _isDashing = true;
        Vector3 dashDirection = new Vector3(_movingVector.x, 0, _movingVector.y).normalized;
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.Translate(dashDirection * dashSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        _isDashing = false;
        _dashCooldownTimer = dashCooldown;
    }
    public IEnumerator IncreaseSpeed(float timeOfBoost, float speedToBoost)
    {
        MoveSpeed += speedToBoost;

        yield return new WaitForSeconds(timeOfBoost);

        MoveSpeed = _initialSpeed;
    }
}
