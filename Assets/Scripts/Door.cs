using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    private Transform player;
    [SerializeField] private Transform particlePosition;
    private void Start() {
        gameObject.SetActive(false); 
    }
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerHitCollider>()) {
            player = other.transform;
            player.parent.GetComponent<PlayerMovement>().portal = particlePosition;
            player.parent.GetComponent<Animator>().Play("PlayerInPortal");
        }
    }
    private void Update() {
        if (player && Vector3.Distance(particlePosition.position, player.position) < 0.15f) {
            Base();
        }
    }
    public virtual void Base() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
