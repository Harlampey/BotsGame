using UnityEngine;

public class ExplodeDestroyedParts : MonoBehaviour {
    [SerializeField] private float force, radius;
    [SerializeField] private Rigidbody[] parts;
    [SerializeField] private Vector3 explodePosition;

    private void Start() {
        Explode();
    }

    private void Explode() {
        foreach (Rigidbody part in parts) {
            part.AddExplosionForce(force, explodePosition, radius);
        }
    }
}
