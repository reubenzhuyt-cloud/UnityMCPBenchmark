using UnityEngine;

/// <summary>
/// L3 伤害配置中枢；L10 接触伤害复用。
/// </summary>
public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private LayerMask targetMask = ~0;
    [SerializeField] private AnimationCurve falloff = AnimationCurve.Linear(0f, 1f, 1f, 0.5f);
    [SerializeField] private Transform source;
    [SerializeField] private float maxDamageRange = 1f;

    private GameObject lastDamagedTarget;
    private float lastDamageTime = float.NegativeInfinity;

    public float Damage => damage;
    public LayerMask TargetMask => targetMask;
    public AnimationCurve Falloff => falloff;
    public Transform Source => source;
    public float MaxDamageRange => maxDamageRange;

    public void SetDamage(float value) => damage = Mathf.Max(0f, value);
    public void SetSource(Transform value) => source = value;
    public void SetMaxDamageRange(float value) => maxDamageRange = Mathf.Max(0f, value);

    /// <summary>按距离 0..1 求衰减系数；未配曲线时返回 1。</summary>
    public float EvaluateFalloff(float normalizedDistance)
    {
        if (falloff == null || falloff.length == 0) return 1f;
        return Mathf.Max(0f, falloff.Evaluate(Mathf.Clamp01(normalizedDistance)));
    }

    public float GetDamageAtDistance(float distance, float maxRange)
    {
        float t = maxRange <= 0f ? 0f : Mathf.Clamp01(distance / maxRange);
        return damage * EvaluateFalloff(t);
    }

    public bool CanDamage(Component other)
    {
        if (other == null) return false;
        return (targetMask.value & (1 << other.gameObject.layer)) != 0;
    }

    public bool CanDamage(GameObject other)
    {
        if (other == null) return false;
        return (targetMask.value & (1 << other.layer)) != 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDamage(collision.gameObject, collision.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TryDamage(other.gameObject, other.transform.position);
    }

    private void TryDamage(GameObject target, Vector2 contactPoint)
    {
        if (!CanDamage(target)) return;
        if (target == lastDamagedTarget && Mathf.Approximately(lastDamageTime, Time.fixedTime)) return;

        var health = target.GetComponent<Health>();
        if (health == null) return;

        lastDamagedTarget = target;
        lastDamageTime = Time.fixedTime;

        float range = maxDamageRange > 0f ? maxDamageRange : 1f;
        float dist = 0f;
        if (source != null)
        {
            dist = Vector2.Distance(source.position, contactPoint);
        }
        health.TakeDamage(GetDamageAtDistance(dist, range));
    }
}
