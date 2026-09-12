# 测试编排工作流（UnityMCP 测试题）

> 目标：对 test1–test10 各关，从「待测基线」分支出发，由 Test Agent 仅用 UnityMCP 从零搭场景并 Play 验证，编排者按答案评分并归档结果。

---

## 1. 目的与角色

| 角色 | 职责 |
|---|---|
| **Orchestrator（主会话）** | 切分支、派发测试 agent、对照评测答案评分、记录结果、复位分支、提交 |
| **Test Agent（= unitymaster）** | 只读 `TASK.md`，仅用 UnityMCP 从零搭建场景并 Play 验证；不写代码、不做 Git |

- Test Agent 全程只能通过 UnityMCP 完成 Unity 操作（场景 / 组件 / Prefab / 物理 / 动画 / UI / VFX / SO / Play / Console）。
- 编排者是唯一可执行 Git 与读答案（`workspace/rubrics/RUBRICS.md`）的角色。

---

## 2. 前置条件

- UnityMCP 已启用，且 Unity Editor 处于前台聚焦状态。
- 当前关卡 `testN` 工作树干净（无未提交改动）。
- 工程无编译错误（Console 0 Error，脚本已就位）。

---

## 3. 每关流程

1. Orchestrator：`checkout testN`。
2. Orchestrator：用第 5 节的提示词模板派发 Test Agent（每次新会话，附上分支号）。
3. Test Agent：读 `TASK.md`，从零搭建场景，保存场景，进入 Play 观察，退出后 `read_console`。
4. Orchestrator：对照 `workspace/rubrics/RUBRICS.md` 逐条评分。
5. Orchestrator：将结果写入 `workspace/results/L0N_result.md`（填 ✅/❌ + 证据、Console 计数、结论）。
6. Orchestrator：将分支复位到「待测基线」。
7. 下一关。

> 建议每关单独开一个 unitymaster 会话，避免上下文串味；单步失败重试 1 次即跳过并记录，勿卡死。

---

## 4. 评分规则

| 结论 | 判定 |
|---|---|
| **PASS** | 全部 rubric 项通过，且 Console 0 Error |
| **FAIL** | 有 rubric 项未通过，或 Console 出现 Error |
| **BLOCKED** | MCP 能力确实做不到（禁止写代码绕过）；须记录阻塞点 |

- 任何「用代码绕过」的实现一律判 FAIL，并注明违规。
- Warning 不直接判失败，但须在结果中列表说明。

---

## 5. 测试 Agent 提示词模板

```text
You are a Unity MCP test agent. Build the scene FROM SCRATCH and verify it.
Spec: TASK.md (repo root) — read it first; it is the ONLY spec you may follow.
Branch: testN (already checked out)

Hard rules:
- ONLY UnityMCP tools (manage_scene/gameobject/components/prefabs/asset/texture/ui/tools/editor, find_gameobjects, read_console, batch_execute).
- NEVER create/edit any .cs; NEVER create_script/apply_text_edits/execute_code; NEVER hand-edit scene/prefab YAML.
- MCP calls serial, or grouped in batch_execute (omit mcp__unityMCP__ prefix inside batch).
- Keep Unity Editor focused in foreground. L6+: first manage_tools activate the needed group(s).
- If a step is impossible via MCP → mark Blocked; do NOT write code to work around.

Procedure: read TASK.md → build per its requirements → save scene → enter Play → observe → exit → read_console.

Return ONLY: scene path / tools used / what you built / Console Error=N Warning=N / blocked items / overall PASS|FAIL|BLOCKED.
```

---

## 6. MCP 实战备忘

- **所有 MCP 调用必须串行**——并行请求会压垮桥接（Timeout / plugin session disconnected）。
- Play 模式下 `manage_components` / `manage_gameobject` 写操作被拒：`This cannot be used during play mode`。运行态要在 Edit 模式设好后进 Play。
- `LayerMask` 属性需传对象 `{"value":N}`，直接传 int 会报错。
- UI Toolkit 可能自动创建 `Assets/UI Toolkit/`，清场时需显式删除该目录。
- 保持 Unity Editor 前台聚焦，否则工具可能失联或超时。
- MCP 调用可串行单发，也可分组进 `batch_execute`；batch 内工具名去掉 `mcp__unityMCP__` 前缀。
- 切分支时 Unity Editor 可保持开启（会触发重导入），但工作树必须干净；切完先让 unitymaster 刷新资产确认无编译错。
