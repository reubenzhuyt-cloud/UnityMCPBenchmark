using UnityEngine;

/// <summary>
/// L4 敌人定义，挂 Prefab 上供 Spawner/验收读取。
/// </summary>
public class EnemyDefinition : MonoBehaviour
{
    [SerializeField] private string enemyId = "basic";
    [SerializeField] private int maxHp = 50;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Sprite icon;

    public string EnemyId => enemyId;
    public int MaxHp => maxHp;
    public float MoveSpeed => moveSpeed;
    public Sprite Icon => icon;

    public void SetEnemyId(string value) => enemyId = value;
    public void SetMaxHp(int value) => maxHp = Mathf.Max(1, value);
    public void SetMoveSpeed(float value) => moveSpeed = Mathf.Max(0f, value);
}
