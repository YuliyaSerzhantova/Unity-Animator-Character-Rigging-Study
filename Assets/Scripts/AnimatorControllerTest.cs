using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorControllerTest : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _movementInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = _movementInput.y;

        if (_animator != null)
        {
            float targetSpeed = Mathf.Abs(vertical);
            _animator.SetFloat("MovementSpeed", targetSpeed, 0.1f, Time.deltaTime);
        }
    }
}
