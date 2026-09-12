using UnityEngine;

/// <summary>
/// L5 关节断裂反馈。Break Force 应与 Joint.breakForce 对齐。
/// </summary>
public class BreakableLink : MonoBehaviour
{
    [SerializeField] private float breakForce = 50f;
    [SerializeField] private SpriteRenderer visual;
    [SerializeField] private Color brokenColor = Color.red;

    private bool broken;

    public float BreakForce => breakForce;
    public bool Broken => broken;

    public void SetBreakForce(float value) => breakForce = Mathf.Max(0f, value);
    public void SetVisual(SpriteRenderer value) => visual = value;

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        broken = true;
        Debug.Log($"[BreakableLink] Joint broken on {name}: {brokenJoint.GetType().Name}", this);
        if (visual != null)
        {
            visual.color = brokenColor;
        }
    }
}
