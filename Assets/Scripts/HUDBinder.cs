using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// L7/L10 HUD 绑定。元素 name 必须与 UXML 一致：hp-label / hp-bar / hp-bar-fill / score-label / status-label。
/// </summary>
public class HUDBinder : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private Health health;

    private Label hpLabel;
    private VisualElement hpBarFill;
    private Label scoreLabel;
    private Label statusLabel;

    public UIDocument UiDocument => uiDocument;
    public Health Health => health;

    public void SetUiDocument(UIDocument value)
    {
        uiDocument = value;
    }

    public void SetHealth(Health value)
    {
        if (health != null)
        {
            health.OnHealthChanged.RemoveListener(OnHealthChanged);
        }
        health = value;
        BindHealth();
        RefreshHealth();
    }

    public void SetScore(int score)
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = $"Score {score}";
        }
    }

    public void SetStatus(string status)
    {
        if (statusLabel != null)
        {
            statusLabel.text = status;
        }
    }

    private void OnEnable()
    {
        CacheElements();
        BindHealth();
        RefreshHealth();
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.OnHealthChanged.RemoveListener(OnHealthChanged);
        }
    }

    private void CacheElements()
    {
        if (uiDocument == null)
        {
            uiDocument = GetComponent<UIDocument>();
        }
        var root = uiDocument != null ? uiDocument.rootVisualElement : null;
        if (root == null) return;

        hpLabel = root.Q<Label>("hp-label");
        hpBarFill = root.Q<VisualElement>("hp-bar-fill");
        scoreLabel = root.Q<Label>("score-label");
        statusLabel = root.Q<Label>("status-label");
    }

    private void BindHealth()
    {
        if (health == null) return;
        health.OnHealthChanged.AddListener(OnHealthChanged);
    }

    private void OnHealthChanged(float normalized)
    {
        ApplyHealth(normalized);
    }

    private void RefreshHealth()
    {
        if (health == null)
        {
            ApplyHealth(1f);
            return;
        }
        ApplyHealth(health.Normalized);
    }

    private void ApplyHealth(float normalized)
    {
        float n = Mathf.Clamp01(normalized);
        if (hpLabel != null && health != null)
        {
            hpLabel.text = $"HP {Mathf.RoundToInt(health.CurrentHealth)}/{Mathf.RoundToInt(health.MaxHealth)}";
        }
        else if (hpLabel != null)
        {
            hpLabel.text = $"HP {Mathf.RoundToInt(n * 100)}/100";
        }

        if (hpBarFill != null)
        {
            hpBarFill.style.width = Length.Percent(n * 100f);
        }
    }
}
