# Task L04 — Prefab 流水线

## 目标
把场景中的敌人原型资产化为 Prefab，并派生一个 Variant；在场景中实例化若干实例，验证实例级 Override 与源 Prefab 属性同步的行为。再配置刷怪器引用 Prefab 资产，进入 Play 后按间隔在指定位置生成敌人。

## 起始状态
- 场景：`Assets/Scenes/Level4_PrefabPipeline_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `EnemyDefinition.cs` — 字段：`enemyId:string`, `maxHp:int`, `moveSpeed:float`, `icon:Sprite`
  - `Spawner.cs` — 字段：`enemyPrefab:GameObject`, `spawnPoints:Transform[]`, `interval:float`

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
