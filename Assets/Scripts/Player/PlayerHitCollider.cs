using UnityEngine;


public class PlayerHitCollider : MonoBehaviour {
    private PlayerMovement playerMovement;
    

    private void Start() {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "EnemyWeapon") {
            playerMovement.GetDamage();
        }
        if (other.GetComponent<Rocket>()) {
            Destroy(other.gameObject);
        }
    }


}
