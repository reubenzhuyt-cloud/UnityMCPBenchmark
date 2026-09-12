using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// L3/L7/L10 共用血量组件。字段名与关卡文档一致，MCP 验收依赖这些名字。
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = -1f;
    [SerializeField] private float regenRate = 0f;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private UnityEvent<float> onHealthChanged;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public float Normalized => maxHealth <= 0f ? 0f : Mathf.Clamp01(currentHealth / maxHealth);
    public bool IsDead => currentHealth <= 0f;
    public Transform HitPoint => hitPoint;
    public UnityEvent OnDeath => onDeath;
    public UnityEvent<float> OnHealthChanged => onHealthChanged;

    private void Awake()
    {
        if (currentHealth < 0f)
        {
            currentHealth = maxHealth;
        }
    }

    private void Update()
    {
        if (IsDead || regenRate <= 0f) return;
        if (currentHealth >= maxHealth) return;
        currentHealth = Mathf.Min(maxHealth, currentHealth + regenRate * Time.deltaTime);
        RaiseChanged();
    }

    public void TakeDamage(float amount)
    {
        if (IsDead || amount <= 0f) return;
        currentHealth = Mathf.Max(0f, currentHealth - amount);
        RaiseChanged();
        if (IsDead)
        {
            onDeath?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        if (IsDead || amount <= 0f) return;
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        RaiseChanged();
    }

    public void SetMaxHealth(float value, bool refill = true)
    {
        maxHealth = Mathf.Max(1f, value);
        if (refill)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
        RaiseChanged();
    }

    public void SetCurrentHealth(float value)
    {
        currentHealth = Mathf.Clamp(value, 0f, maxHealth);
        RaiseChanged();
    }

    private void RaiseChanged()
    {
        onHealthChanged?.Invoke(Normalized);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        maxHealth = Mathf.Max(1f, maxHealth);
        if (currentHealth < 0f)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }
    }
#endif
}
