# Task L05 — 物理进阶：关节 / 碰撞矩阵 / 物理材质

## 目标
搭建一个包含地面、玩家、钟摆、弹簧链、门与陷阱的 2D 物理场景，配置 Layer 碰撞矩阵与物理材质，并连接各类 2D 关节。进入 Play 后应能观察到摆动、拉伸回弹、关节受力断开，以及指定 Tag 进入触发区时驱动门开关。

## 起始状态
- 场景：`Assets/Scenes/Level5_PhysicsJoints_Matrix_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `SpringPlayer.cs` — 字段：`body:Rigidbody2D`, `pushForce:float`
  - `BreakableLink.cs` — 字段：`breakForce:float`
  - `GateTrigger.cs` — 字段：`requiredTag:string = "Player"`, `door:GameObject`

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
