using UnityEngine;

/// <summary>
/// L10 敌人追踪玩家。
/// </summary>
public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 0.35f;
    [SerializeField] private bool autoFindPlayer = true;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float retargetInterval = 0.5f;

    private Rigidbody2D body;
    private float retargetTimer;

    public Transform Target => target;
    public float MoveSpeed => moveSpeed;

    public void SetTarget(Transform value) => target = value;
    public void SetMoveSpeed(float value) => moveSpeed = Mathf.Max(0f, value);

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (!IsTargetValid() && autoFindPlayer)
        {
            TryFindTarget();
        }
    }

    private void TryFindTarget()
    {
        var player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null) return;
        if (IsDeadTarget(player.transform)) return;
        target = player.transform;
    }

    private bool IsTargetValid()
    {
        return target != null && !IsDeadTarget(target);
    }

    private static bool IsDeadTarget(Transform candidate)
    {
        if (candidate == null) return false;
        var health = candidate.GetComponent<Health>();
        return health != null && health.IsDead;
    }

    private void FixedUpdate()
    {
        if (!IsTargetValid())
        {
            if (!autoFindPlayer) return;

            retargetTimer += Time.fixedDeltaTime;
            float wait = retargetInterval > 0f ? retargetInterval : 0.5f;
            if (retargetTimer < wait) return;
            retargetTimer = 0f;

            TryFindTarget();
            if (!IsTargetValid()) return;
        }

        Vector2 pos = body != null ? body.position : (Vector2)transform.position;
        Vector2 to = (Vector2)target.position - pos;
        float dist = to.magnitude;
        if (dist <= stopDistance) return;

        Vector2 step = to / dist * moveSpeed * Time.fixedDeltaTime;
        if (body != null)
        {
            body.MovePosition(pos + step);
        }
        else
        {
            transform.position = pos + step;
        }
    }
}
