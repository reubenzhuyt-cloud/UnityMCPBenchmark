using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// L8 轨迹跟随：把 followTarget 位置写入 LineRenderer。
/// </summary>
public class TrailFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private LineRenderer line;
    [SerializeField] private int maxPoints = 32;
    [SerializeField] private float minDistance = 0.05f;

    private readonly List<Vector3> points = new List<Vector3>();

    public Transform FollowTarget => followTarget;
    public LineRenderer Line => line;

    public void SetFollowTarget(Transform value) => followTarget = value;
    public void SetLine(LineRenderer value)
    {
        line = value;
        if (line != null)
        {
            line.positionCount = 0;
        }
        points.Clear();
    }

    private void LateUpdate()
    {
        if (line == null || followTarget == null) return;

        Vector3 pos = followTarget.position;
        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], pos) >= minDistance)
        {
            points.Add(pos);
            while (points.Count > maxPoints)
            {
                points.RemoveAt(0);
            }
            line.positionCount = points.Count;
            for (int i = 0; i < points.Count; i++)
            {
                line.SetPosition(i, points[i]);
            }
        }
    }
}
