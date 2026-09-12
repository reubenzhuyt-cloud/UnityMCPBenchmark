# Task L06 — Animator 与动画资产

## 目标
创建英雄角色的动画控制器与动画剪辑资产（含参数、状态与过渡），把 Animator 挂到场景角色并连好驱动脚本。进入 Play 后按键驱动参数，观察状态在 Idle / Run / Attack 之间切换。

## 起始状态
- 场景：`Assets/Scenes/Level6_AnimatorBlend_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `CharacterAnimDriver.cs` — 字段：`animator:Animator`, `speedSmoothTime:float = 0.1f`
  - `AnimEventRelay.cs`（可选）— 字段：`onFootstep:UnityEvent`, `onAttackHit:UnityEvent`

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
