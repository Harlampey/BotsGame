using UnityEngine;

public class JoystickLooker : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Transform target;
    private void Start() {
        _transform = GetComponent<Transform>();
    }
    private void Update() {
        _transform.LookAt(target);
    }
}
