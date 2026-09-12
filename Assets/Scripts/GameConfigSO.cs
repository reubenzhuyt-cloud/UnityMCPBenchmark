using UnityEngine;

/// <summary>
/// L9 游戏配置 ScriptableObject。CreateAssetMenu 路径固定，便于 MCP 创建。
/// </summary>
[CreateAssetMenu(fileName = "GameConfig", menuName = "AItest/GameConfig", order = 0)]
public class GameConfigSO : ScriptableObject
{
    [SerializeField] private string difficultyName = "Easy";
    [SerializeField] private int enemyCount = 2;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private Color themeColor = Color.cyan;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float[] waveGaps = { 1f, 1.5f };

    public string DifficultyName => difficultyName;
    public int EnemyCount => enemyCount;
    public float EnemySpeed => enemySpeed;
    public Color ThemeColor => themeColor;
    public GameObject EnemyPrefab => enemyPrefab;
    public float[] WaveGaps => waveGaps;
}
