using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 0.15f;

    private Vector2 _movingVector;
    public void OnMove(InputAction.CallbackContext context)
    {
        _movingVector = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        Vector3 movement = new Vector3(_movingVector.x * moveSpeed * Time.deltaTime, 0, _movingVector.y * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);

        transform.Translate(movement, Space.World);
    }
}
