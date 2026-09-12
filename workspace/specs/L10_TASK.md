# Task L10 — 综合微游戏（Capstone）

## 目标
综合运用多个工具组与批量调用，搭建一个可完整游玩的 2D 平台微游戏：玩家移动跳跃、敌人生成与追击、接触伤害、击杀计分、胜负 HUD 与死亡特效。所有玩法逻辑均由预写脚本提供，你只负责用 MCP 搭建与连线，并保证最终 Console 无 Error。

## 起始状态
- 场景：`Assets/Scenes/Level10_Integration_Microgame_Test.unity`（仅 Main Camera + Directional Light）
- 已提供脚本（禁止修改）：
  - `PlayerMovement2D.cs` — 来源 L2：移动与跳跃
  - `Health.cs` — 来源 L3：血量
  - `DamageDealer.cs` — 来源 L3：伤害与层掩码
  - `EnemyChase.cs` — L10 新增：朝玩家移动（预写）
  - `Spawner.cs` — 来源 L4：按配置刷怪
  - `ScoreManager.cs` — L10 新增：击杀加分，静态/单例皆可
  - `GameDirector.cs` — L10 新增：Ready→Play→Win/Lose，读分/读玩家存活
  - `CameraFollow2D.cs` — L10 新增：跟随玩家
  - `HUDBinder.cs` — 来源 L7：血条/分数/胜负文案
  - `VFXTrigger.cs` — 来源 L8：死亡/拾取特效
  - `GameConfigSO.cs` — 来源 L9：难度与刷怪参数
  - `LevelBootstrap.cs` — 来源 L9：按 SO 生成

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
