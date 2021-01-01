using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float maxLeftPosition, maxRightPosition;
    [SerializeField] private Vector3 offset;

    private void Start() {
        if (!target) {
            target = FindObjectOfType<PlayerMovement>().transform;
        }
    }
    private void LateUpdate() {
        if (target.position.x > maxLeftPosition && target.position.x < maxRightPosition) {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        } else {
            transform.position = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z);
        }
    }
}
