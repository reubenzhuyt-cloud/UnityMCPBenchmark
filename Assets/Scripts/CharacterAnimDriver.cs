using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// L6 只驱动 Animator 参数，不实现移动物理。
/// </summary>
public class CharacterAnimDriver : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speedSmoothTime = 0.1f;
    [SerializeField] private bool isGrounded = true;

    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
    private static readonly int AttackHash = Animator.StringToHash("Attack");

    private float currentSpeed;
    private float speedVelocity;

    public Animator Animator => animator;
    public float SpeedSmoothTime => speedSmoothTime;

    public void SetAnimator(Animator value) => animator = value;
    public void SetIsGrounded(bool value) => isGrounded = value;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (animator == null) return;

        float input = ReadMoveInput();
        float target = Mathf.Abs(input);
        currentSpeed = Mathf.SmoothDamp(currentSpeed, target, ref speedVelocity, speedSmoothTime);

        animator.SetFloat(SpeedHash, currentSpeed);
        animator.SetBool(IsGroundedHash, isGrounded);

        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.spaceKey.wasPressedThisFrame ||
                (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame))
            {
                animator.SetTrigger(AttackHash);
            }
        }
    }

    private static float ReadMoveInput()
    {
        float value = 0f;
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) value -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) value += 1f;
        }

        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            float stick = gamepad.leftStick.x.ReadValue();
            if (Mathf.Abs(stick) > Mathf.Abs(value))
            {
                value = stick;
            }
        }

        return Mathf.Clamp(value, -1f, 1f);
    }
}
