using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
    [SerializeField] float time;
    private void Start() {
        Invoke("DestroyObject", time);
    }
    private void DestroyObject() {
        Destroy(gameObject);
    }
}
