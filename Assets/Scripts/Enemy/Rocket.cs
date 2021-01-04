using UnityEngine;

public class Rocket : MonoBehaviour {
    public float Speed;
    [SerializeField] private GameObject explodeParticle;

    private void Start() {
        Invoke("DestroyRocket", 10f);
    }
    private void Update() {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void DestroyRocket() {
        Vector3 pos = transform.position;
        Instantiate(explodeParticle, pos, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 12) DestroyRocket(); //Destroying on entered to static objects
    }
}
