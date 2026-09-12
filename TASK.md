# Task L03 — 组件属性深配 & 对象引用连线

## 目标
搭建一套包含玩家、敌人与可拾取物的场景对象树，为它们挂载预写脚本并完成复杂的序列化字段配置与跨对象引用连线。进入 Play 后，拾取物触发时应真实影响玩家血量，以证明 Inspector 引用确实生效。

## 起始状态
- 场景：`Assets/Scenes/Level3_ComponentWiring_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `Health.cs` — 字段：`maxHealth:float`, `regenRate:float`, `hitPoint:Transform`, `onDeath:UnityEvent`
  - `DamageDealer.cs` — 字段：`damage:float`, `targetMask:LayerMask`, `falloff:AnimationCurve`, `source:Transform`
  - `Pickup.cs` — 字段：`pickupType:PickupType{Health,Ammo,Coin}`, `amount:float`, `linkedHealth:Health`

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
