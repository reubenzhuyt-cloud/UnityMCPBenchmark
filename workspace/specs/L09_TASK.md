# Task L09 — ScriptableObject / 资产管线 / 编辑器控制

## 目标
基于预写 ScriptableObject 类型创建两份难度配置资产，搭建一个按配置生成敌人并对背景染色的主场景，并额外准备一个附加场景。通过编辑器控制进出 Play，并切换配置验证运行结果（敌人数与主题色）随配置变化。

## 起始状态
- 场景：`Assets/Scenes/Level9_SO_AssetPipeline_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `GameConfigSO.cs` — 字段：`difficultyName:string`, `enemyCount:int`, `enemySpeed:float`, `themeColor:Color`, `enemyPrefab:GameObject`, `waveGaps:float[]`
  - `LevelBootstrap.cs` — 字段：`config:GameConfigSO`, `spawnRoot:Transform`, `backdrop:SpriteRenderer`
  - `ConfigReloader.cs`（可选）

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
