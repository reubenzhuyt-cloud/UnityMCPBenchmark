using UnityEngine;

/// <summary>
/// L5 门禁触发器：指定 Tag 进入 Trigger 时开关 door。
/// </summary>
public class GateTrigger : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";
    [SerializeField] private GameObject door;
    [SerializeField] private bool openOnEnter = true;

    public string RequiredTag => requiredTag;
    public GameObject Door => door;

    public void SetDoor(GameObject value) => door = value;
    public void SetRequiredTag(string value) => requiredTag = value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (door == null) return;
        if (!other.CompareTag(requiredTag)) return;
        door.SetActive(!openOnEnter);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (door == null) return;
        if (!other.CompareTag(requiredTag)) return;
        door.SetActive(openOnEnter);
    }
}
