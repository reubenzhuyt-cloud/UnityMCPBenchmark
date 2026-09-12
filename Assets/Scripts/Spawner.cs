using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// L4/L10 刷怪器。enemyPrefab 必须是 Prefab 资产引用，不是场景实例。
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float interval = 1f;
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private int maxAlive = 20;

    private readonly List<GameObject> aliveInstances = new List<GameObject>();
    private float timer;

    public GameObject EnemyPrefab => enemyPrefab;
    public Transform[] SpawnPoints => spawnPoints;
    public float Interval => interval;
    public int AliveCount => aliveInstances.Count;
    public int MaxAlive => maxAlive;

    public void SetEnemyPrefab(GameObject prefab) => enemyPrefab = prefab;
    public void SetSpawnPoints(Transform[] points) => spawnPoints = points;
    public void SetInterval(float value) => interval = Mathf.Max(0.05f, value);

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnOnce();
        }
    }

    private void Update()
    {
        PruneDestroyed();

        if (enemyPrefab == null || spawnPoints == null || spawnPoints.Length == 0) return;
        if (aliveInstances.Count >= maxAlive) return;

        timer += Time.deltaTime;
        if (timer < interval) return;
        timer = 0f;
        SpawnOnce();
    }

    public GameObject SpawnOnce()
    {
        PruneDestroyed();

        if (enemyPrefab == null || spawnPoints == null || spawnPoints.Length == 0) return null;
        if (aliveInstances.Count >= maxAlive) return null;

        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (point == null) return null;

        var instance = Instantiate(enemyPrefab, point.position, Quaternion.identity);
        if (instance != null)
        {
            aliveInstances.Add(instance);
        }
        return instance;
    }

    public void NotifyDespawned()
    {
        PruneDestroyed();
    }

    private void PruneDestroyed()
    {
        for (int i = aliveInstances.Count - 1; i >= 0; i--)
        {
            if (aliveInstances[i] == null)
            {
                aliveInstances.RemoveAt(i);
            }
        }
    }
}
