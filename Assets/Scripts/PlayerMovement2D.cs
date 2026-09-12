using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] public Transform groundCheck;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 2f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool jumpRequested;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = gravityScale;
        }
    }

    private void Update()
    {
        moveInput = 0f;
        var keyboard = Keyboard.current;
        var gamepad = Gamepad.current;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveInput -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveInput += 1f;
            if (keyboard.spaceKey.wasPressedThisFrame) jumpRequested = true;
        }

        if (gamepad != null)
        {
            float stickX = gamepad.leftStick.x.ReadValue();
            if (Mathf.Abs(stickX) > Mathf.Abs(moveInput))
            {
                moveInput = stickX;
            }
            if (gamepad.buttonSouth.wasPressedThisFrame) jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (jumpRequested)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            jumpRequested = false;
        }
    }

    private bool IsGrounded()
    {
        if (groundCheck == null) return false;
        return Physics2D.OverlapPoint(groundCheck.position, LayerMask.GetMask("Default"));
    }
}
