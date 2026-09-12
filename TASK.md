# Task L08 — VFX / 材质 / 着色器

## 目标
创建一个包含粒子系统、脉动目标与轨迹线的视觉特效场景；生成程序化贴图，创建教学级材质/着色器并应用到目标上。进入 Play 后应能观察到粒子发射、目标颜色脉动与 LineRenderer 轨迹。

## 起始状态
- 场景：`Assets/Scenes/Level8_VFX_Material_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `VFXTrigger.cs` — 字段：`ps:ParticleSystem`, `playOnEnter:bool = true`
  - `ColorPulse.cs` — 字段：`target:SpriteRenderer`, `colors:Gradient`（或 `Color a/b`）, `speed:float`
  - `TrailFollow.cs` — 字段：`followTarget:Transform`, `line:LineRenderer`

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
