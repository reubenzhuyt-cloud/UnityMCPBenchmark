using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// L6 可选：Animation Event 转发。
/// </summary>
public class AnimEventRelay : MonoBehaviour
{
    [SerializeField] private UnityEvent onFootstep;
    [SerializeField] private UnityEvent onAttackHit;

    public UnityEvent OnFootstep => onFootstep;
    public UnityEvent OnAttackHit => onAttackHit;

    public void Footstep()
    {
        onFootstep?.Invoke();
    }

    public void AttackHit()
    {
        onAttackHit?.Invoke();
    }
}
