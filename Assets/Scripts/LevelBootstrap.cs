using UnityEngine;

/// <summary>
/// L9 按 SO 启动关卡：染色背景 + 按 enemyCount 生成占位敌人。
/// </summary>
public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private GameConfigSO config;
    [SerializeField] private Transform spawnRoot;
    [SerializeField] private SpriteRenderer backdrop;

    public GameConfigSO Config => config;
    public Transform SpawnRoot => spawnRoot;
    public SpriteRenderer Backdrop => backdrop;

    public void SetConfig(GameConfigSO value) => config = value;
    public void SetSpawnRoot(Transform value) => spawnRoot = value;
    public void SetBackdrop(SpriteRenderer value) => backdrop = value;

    private void Awake()
    {
        Apply();
    }

    [ContextMenu("Apply Config")]
    public void Apply()
    {
        if (config == null)
        {
            Debug.LogWarning("[LevelBootstrap] Config is null.", this);
            return;
        }

        if (backdrop != null)
        {
            backdrop.color = config.ThemeColor;
        }

        if (config.EnemyPrefab == null || spawnRoot == null) return;

        int count = Mathf.Max(0, config.EnemyCount);
        for (int i = 0; i < count; i++)
        {
            Vector3 offset = new Vector3(i * 1.2f, 0f, 0f);
            Instantiate(config.EnemyPrefab, spawnRoot.position + offset, Quaternion.identity, spawnRoot);
        }
    }
}
