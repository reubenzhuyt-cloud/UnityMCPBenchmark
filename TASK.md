# Task L01 — Sprite 排序与 2D 碰撞体

## 目标
在 2D 场景中从零搭建一个背景加若干金币的演示，正确设置精灵排序（背景位于金币之后），并为金币对象批量配置 2D 碰撞体，使 Play 时的层级与物理表现正确。

## 起始状态
- 场景：`Assets/Scenes/SampleScene.unity`（仅 Main Camera + Directional Light）
- 无预写脚本

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
