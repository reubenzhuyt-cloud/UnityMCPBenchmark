using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// L5 玩家推力输入，驱动弹簧/摆观察。
/// </summary>
public class SpringPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float pushForce = 20f;

    public Rigidbody2D Body => body;
    public float PushForce => pushForce;

    public void SetBody(Rigidbody2D value) => body = value;

    private void Awake()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (body == null) return;

        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector2 dir = Vector2.zero;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) dir.x -= 1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) dir.x += 1f;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) dir.y -= 1f;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) dir.y += 1f;

        if (dir.sqrMagnitude > 0.01f)
        {
            body.AddForce(dir.normalized * pushForce, ForceMode2D.Force);
        }
    }
}
