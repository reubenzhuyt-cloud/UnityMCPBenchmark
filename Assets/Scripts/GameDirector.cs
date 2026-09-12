using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// L10 游戏流程：Ready → Playing → Win / Lose。
/// </summary>
public class GameDirector : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Playing,
        Win,
        Lose
    }

    [SerializeField] private Health playerHealth;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private HUDBinder hud;
    [SerializeField] private int targetScore = 10;
    [SerializeField] private float readyDuration = 1f;
    [SerializeField] private UnityEvent<GameState> onStateChanged;

    private GameState state = GameState.Ready;
    private float readyTimer;

    public GameState State => state;
    public UnityEvent<GameState> OnStateChanged => onStateChanged;

    public void SetPlayerHealth(Health value)
    {
        if (playerHealth != null)
        {
            playerHealth.OnDeath.RemoveListener(OnPlayerDeath);
        }
        playerHealth = value;
        if (playerHealth != null)
        {
            playerHealth.OnDeath.AddListener(OnPlayerDeath);
        }
    }

    public void SetScoreManager(ScoreManager value) => scoreManager = value;
    public void SetHud(HUDBinder value) => hud = value;
    public void SetTargetScore(int value) => targetScore = Mathf.Max(1, value);

    private void Start()
    {
        SetPlayerHealth(playerHealth);
        if (scoreManager != null)
        {
            scoreManager.SetTargetScore(targetScore);
            scoreManager.OnTargetReached.AddListener(OnTargetReached);
        }
        EnterReady();
    }

    private void Update()
    {
        if (state != GameState.Ready) return;
        readyTimer += Time.deltaTime;
        if (readyTimer >= readyDuration)
        {
            EnterPlaying();
        }
    }

    private void EnterReady()
    {
        state = GameState.Ready;
        readyTimer = 0f;
        ApplyHud("Ready");
        onStateChanged?.Invoke(state);
    }

    private void EnterPlaying()
    {
        state = GameState.Playing;
        ApplyHud("Playing");
        onStateChanged?.Invoke(state);
    }

    private void OnPlayerDeath()
    {
        if (state != GameState.Playing) return;
        state = GameState.Lose;
        ApplyHud("Lose");
        onStateChanged?.Invoke(state);
    }

    private void OnTargetReached()
    {
        if (state != GameState.Playing) return;
        state = GameState.Win;
        ApplyHud("Win");
        onStateChanged?.Invoke(state);
    }

    private void ApplyHud(string status)
    {
        if (hud == null) return;
        hud.SetStatus(status);
        if (scoreManager != null)
        {
            hud.SetScore(scoreManager.Score);
        }
    }
}
