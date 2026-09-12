# Task L07 — UI Toolkit HUD

## 目标
创建 UI Toolkit 的 HUD 资产（UXML / USS），在场景中通过 UIDocument 与绑定脚本把玩家血量与分数显示到 Game 视图。进入 Play 或改变血量数据时，HUD 文本与进度条应随之响应。

## 起始状态
- 场景：`Assets/Scenes/Level7_UIToolkit_HUD_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `Health.cs` — 字段：`maxHealth:float`, `currentHealth:float`, `onHealthChanged:事件(float normalized)`（或提供 `Normalized:float`）
  - `HUDBinder.cs` — 字段：`uiDocument:UIDocument`, `health:Health`

## 约束
- 仅用 UnityMCP 工具完成；禁止创建/修改任何 `.cs`；禁止手改场景/prefab YAML。
- MCP 调用串行，或用 `batch_execute`（batch 内工具名去掉 `mcp__unityMCP__` 前缀）。
- 保持 Unity Editor 前台聚焦；L6+ 先 `manage_tools activate` 所需工具组。

## 回报格式
- 场景路径 / 使用工具
- 你完成的搭建内容
- Console：Error=N Warning=N
- 阻塞项
- 结论：PASS / FAIL / BLOCKED
