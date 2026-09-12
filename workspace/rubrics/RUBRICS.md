# 验收标准（答案，测试 agent 不可见）

## L01
- [ ] 背景与金币的排序正确（背景在金币之后）
- [ ] 金币批量配置了 2D 碰撞体
- [ ] Play 后层级与物理表现正确
- [ ] Console 无 Error

## L02
- [ ] Player2D 具备 Rigidbody2D + Collider2D，物理表现正确
- [ ] PlayerMovement2D 已挂载且 `groundCheck` 引用非 None
- [ ] Play 后玩家可左右移动、接地时可跳跃
- [ ] Console 无 Error

## L03
- [ ] Hierarchy 与目标结构一致，无 missing script
- [ ] 所有 Inspector 引用非 None：`hitPoint`、`linkedHealth`、`source`
- [ ] `LayerMask`、`AnimationCurve`、枚举字段显示正确
- [ ] Play 后：触碰 Pickup 能影响 Player 的 Health 数值
- [ ] Console 无 Error

## L04
- [ ] `Assets/Prefabs/` 中存在 Basic 与 Elite Variant
- [ ] 未 override 的 Basic 实例在改源后属性同步
- [ ] 实例 B 的 `maxHp=200` 为实例覆盖，且可被识别为 override
- [ ] Elite 保留与源的差异（HP/颜色）
- [ ] `Spawner.enemyPrefab` 指向资产而非场景对象
- [ ] Play 后 Spawner 能在 SpawnPoints 生成敌人
- [ ] Console 无 Error

## L05
- [ ] Layer 碰撞矩阵与规划表一致（在 Physics2D 设置里可核对）
- [ ] Play 后钟摆可摆动；弹簧链有拉伸/回弹
- [ ] 加大作用力后关节可断开，`BreakableLink` 有反应
- [ ] Enemy 与 Hazard 互不产生碰撞
- [ ] GateTrigger 在正确 Tag 进入时能驱动 Door
- [ ] Console 无 Error（关节 disconnected 警告需记录）

## L06
- [ ] `animation` 工具组已激活且工具可调用
- [ ] `Assets/Animation/Hero.controller` 存在，参数三件套齐全
- [ ] 状态与 Condition 正确（Inspector 可读）
- [ ] Hero 上 Animator Controller 已赋值，无 missing
- [ ] Play 后按住移动键 Speed 上升并在 Idle↔Run 切换
- [ ] 触发 Attack 能进入 Attack 并回到 Idle
- [ ] Console 无 Error

## L07
- [ ] `ui` 工具组已激活
- [ ] `Assets/UI/HUD.uxml` 与 `HUD.uss` 存在
- [ ] UIDocument 的 SourceAsset / PanelSettings 均非 None
- [ ] HUDBinder 两个引用已连好
- [ ] Game 视图能看到 HUD 文案与样式（非空白）
- [ ] 修改 Health 后条/文本有响应（Play 中或通过脚本事件）
- [ ] Console 无 UXML/USS 相关 Error

## L08
- [ ] `vfx` 工具组已激活
- [ ] `Assets/Materials/M_Tint` 存在且颜色/贴图生效
- [ ] 自定义 shader 若使用：Game 视图**非粉色**，Console 无 shader error
- [ ] Play 后粒子持续发射或可被 Trigger 触发
- [ ] PulseTarget 颜色在变化
- [ ] LineRenderer 有可见轨迹
- [ ] Console 无 Error

## L09
- [ ] `scripting_ext` 工具组已激活
- [ ] `Assets/Config/` 下有两个有效 `.asset`，类型为 GameConfigSO
- [ ] SO 中数组与 Object 引用不丢
- [ ] LevelBootstrap 引用 Easy 时，Play 生成 2 个敌人且主题色正确
- [ ] 换 Hard 后为 6 个且颜色变化
- [ ] Additive 场景存在且 Build Settings 含两场景（若支持）
- [ ] Play Mode 进出正常，无残留 DontDestroy 污染导致的重复对象（可接受范围需记录）
- [ ] Console 无 Error

## L10
- [ ] 场景可完整游玩上述手测流程
- [ ] Player / Enemy / Spawner / HUD / Director 引用无 None、无 missing script
- [ ] 至少 1 个 Basic + 1 个 Elite（或变体）行为差异可感知
- [ ] 死亡特效可见
- [ ] Win 与 Lose 各能触发一次
- [ ] `read_console`：**0 Error**（Warning 需列表说明）
- [ ] 通过 `batch_execute` 创建的对象数量可在报告中举证（日志/层级）
- [ ] 最终 commit 含：预写脚本 + MCP 搭建的场景/资产
