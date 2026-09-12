using UnityEngine;

/// <summary>
/// L10 2D 摄像机跟随。
/// </summary>
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private bool autoFindPlayer = true;
    [SerializeField] private string playerTag = "Player";

    private Vector3 velocity;

    public Transform Target => target;

    public void SetTarget(Transform value) => target = value;

    private void Start()
    {
        if (target == null && autoFindPlayer)
        {
            var player = GameObject.FindGameObjectWithTag(playerTag);
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 desired = target.position + offset;
        desired.z = offset.z;
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
    }
}
