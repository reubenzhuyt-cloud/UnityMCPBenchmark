using UnityEngine;

/// <summary>
/// L3 拾取物：Trigger 进入时作用在 linkedHealth 上。
/// </summary>
public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Health,
        Ammo,
        Coin
    }

    [SerializeField] private PickupType pickupType = PickupType.Health;
    [SerializeField] private float amount = 25f;
    [SerializeField] private Health linkedHealth;

    public PickupType Type => pickupType;
    public float Amount => amount;
    public Health LinkedHealth => linkedHealth;

    public void SetLinkedHealth(Health health) => linkedHealth = health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (linkedHealth == null)
        {
            linkedHealth = other.GetComponentInParent<Health>();
            if (linkedHealth == null) return;
        }

        switch (pickupType)
        {
            case PickupType.Health:
                linkedHealth.Heal(amount);
                break;
            case PickupType.Ammo:
            case PickupType.Coin:
                // 分数/弹药由 ScoreManager 等外部系统处理；本关仅验证引用连线。
                break;
        }

        gameObject.SetActive(false);
    }
}
