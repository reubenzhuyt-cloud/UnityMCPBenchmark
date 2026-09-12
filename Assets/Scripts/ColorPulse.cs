using UnityEngine;

/// <summary>
/// L8 颜色脉冲。优先 SpriteRenderer，否则可选 Material。
/// </summary>
public class ColorPulse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [SerializeField] private Color colorA = Color.cyan;
    [SerializeField] private Color colorB = Color.magenta;
    [SerializeField] private Gradient colors;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool useGradient;

    private float time;

    public SpriteRenderer Target => target;
    public float Speed => speed;

    public void SetTarget(SpriteRenderer value) => target = value;
    public void SetSpeed(float value) => speed = Mathf.Max(0f, value);
    public void SetColors(Color a, Color b)
    {
        colorA = a;
        colorB = b;
        useGradient = false;
    }

    private void Update()
    {
        if (target == null) return;
        time += Time.deltaTime * speed;
        float t = Mathf.PingPong(time, 1f);
        target.color = useGradient && colors != null
            ? colors.Evaluate(t)
            : Color.Lerp(colorA, colorB, t);
    }
}
