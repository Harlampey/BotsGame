using UnityEngine;

public abstract class Bonus : MonoBehaviour {
    private Transform mesh;
    private bool canPick;
    [SerializeField] private bool showUpgradeParticleEffect = true;
    private void Start() {
        mesh = GetComponentInChildren<Transform>();
        Invoke("AllowPick", 0.4f);
    }
    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<PlayerHitCollider>() && canPick) {
            if (showUpgradeParticleEffect) other.GetComponentInParent<PlayerMovement>().ShowItemPickEffect();
            PickItem(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void Update() {
        mesh.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
    private void AllowPick() {
        canPick = true;
    }
    public virtual void PickItem(GameObject other) {

    }
}
