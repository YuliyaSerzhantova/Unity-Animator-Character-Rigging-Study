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
        //float speedInput = _movementInput.y;
        //float movementSpeed = Mathf.Max(0f, speedInput);
        //if (_animator != null)
        //{
        //    float currentSpeed = _animator.GetFloat("MovementSpeed");
        //    _animator.SetFloat("MovementSpeed", Mathf.Lerp(currentSpeed, movementSpeed, Time.deltaTime * 10f));
        //}
        float vertical = _movementInput.y;

        if (_animator != null)
        {
            // Целевое значение скорости, куда мы хотим прийти (0 при отпускании W/S, 1 при нажатии W/S)
            float targetSpeed = Mathf.Abs(vertical);

            // Использование перегруженного метода SetFloat с параметрами damping и deltaTime
            // 0.1f - это время сглаживания (dampTime) в секундах.
            // Time.deltaTime - это время, прошедшее с предыдущего кадра.
            _animator.SetFloat("MovementSpeed", targetSpeed, 0.1f, Time.deltaTime);
        }
    }
}
