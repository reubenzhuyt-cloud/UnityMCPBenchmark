using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// L9 可选：按键重读 config 并刷新背景色，便于改 SO 后热验证。
/// </summary>
public class ConfigReloader : MonoBehaviour
{
    [SerializeField] private LevelBootstrap bootstrap;
    [SerializeField] private Key reloadKey = Key.R;

    public LevelBootstrap Bootstrap => bootstrap;

    public void SetBootstrap(LevelBootstrap value) => bootstrap = value;

    private void Update()
    {
        if (bootstrap == null) return;
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (!keyboard[reloadKey].wasPressedThisFrame) return;

        // 只刷新背景色，避免重复 Instantiate。
        var config = bootstrap.Config;
        var backdrop = bootstrap.Backdrop;
        if (config != null && backdrop != null)
        {
            backdrop.color = config.ThemeColor;
            Debug.Log($"[ConfigReloader] Applied theme '{config.DifficultyName}'.", this);
        }
    }
}
