# Task L02 — Player2D 物理与移动脚本挂载

## 目标
从零搭建一个 2D 玩家与地面，为玩家配置刚体与碰撞体，挂载预写脚本 PlayerMovement2D 并完成引用连线，使 Play 后玩家可左右移动并在接地时跳跃。

## 起始状态
- 场景：`Assets/Scenes/Level2_Player2D_PhysicsFix_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `PlayerMovement2D.cs` — 字段：`groundCheck:Transform`, `moveSpeed:float`, `jumpForce:float`, `gravityScale:float`

## 约束
- 仅用 UnityMCP 工具完成；禁止创建/修改任何 `.cs`；禁止手改场景/prefab YAML。
- MCP 调用串行，或用 `batch_execute`（batch 内工具名去掉 `mcp__unityMCP__` 前缀）。
- 保持 Unity Editor 前台聚焦。

## 回报格式
- 场景路径 / 使用工具
- 你完成的搭建内容
- Console：Error=N Warning=N
- 阻塞项
- 结论：PASS / FAIL / BLOCKED
