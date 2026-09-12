using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// L10 计分。简单单例，供击杀/拾取调用。
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private int score;
    [SerializeField] private int targetScore = 10;
    [SerializeField] private UnityEvent<int> onScoreChanged;
    [SerializeField] private UnityEvent onTargetReached;

    private bool targetReached;

    public int Score => score;
    public int TargetScore => targetScore;
    public UnityEvent<int> OnScoreChanged => onScoreChanged;
    public UnityEvent OnTargetReached => onTargetReached;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void SetTargetScore(int value) => targetScore = Mathf.Max(1, value);

    public void AddScore(int amount)
    {
        if (targetReached || amount == 0) return;
        score = Mathf.Max(0, score + amount);
        onScoreChanged?.Invoke(score);
        if (!targetReached && score >= targetScore)
        {
            targetReached = true;
            onTargetReached?.Invoke();
        }
    }

    public void ResetScore()
    {
        score = 0;
        targetReached = false;
        onScoreChanged?.Invoke(score);
    }
}
