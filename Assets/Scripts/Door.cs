using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    private void Start() {
        gameObject.SetActive(false); 
    }
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerHitCollider>()) {
            Base();
        }
    }
    public virtual void Base() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
