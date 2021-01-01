using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    [SerializeField] private Transform looker, objectToRotate;
    [SerializeField] private float offset;
    public float RotationSpeed;

    private void Start() {
        if (!looker) {
            looker = FindObjectOfType<JoystickLooker>().transform;
        }
    }
    void Update() {
        if (looker.eulerAngles.y == 90) {
            objectToRotate.rotation = Quaternion.Lerp(objectToRotate.rotation, Quaternion.Euler(new Vector3(0, looker.eulerAngles.x - 90 + offset, looker.eulerAngles.z)), RotationSpeed * Time.deltaTime);
        }
        if (looker.eulerAngles.y == 270) {
            objectToRotate.rotation = Quaternion.Lerp(objectToRotate.rotation, Quaternion.Euler(new Vector3(0, looker.eulerAngles.x - 90 + offset, looker.eulerAngles.z) * -1), RotationSpeed * Time.deltaTime);
        }

    }
}
