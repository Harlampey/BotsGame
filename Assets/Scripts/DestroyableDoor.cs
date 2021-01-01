using UnityEngine;

public class DestroyableDoor : MonoBehaviour {
    [SerializeField]private GameObject destroyedDoor;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerWeapon") {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            Instantiate(destroyedDoor, pos, rot);
            Destroy(gameObject);
        }
    }
}
