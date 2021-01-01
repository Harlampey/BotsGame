using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] private Transform weapons;
    [SerializeField] float weaponsRotationSpeed;
    [SerializeField] private Transform mesh, character;
    [SerializeField] private List<Rigidbody> rigidbodyParts;
    public float Distance = 12f;
    public float rotationSpeed = 8f;
    [HideInInspector]public Animator animator;

    [Space]
    [SerializeField] private float explodeForce;
    [SerializeField] private GameObject destroyedFloater;

    [Space]
    [Range(0, 100)]
    public int spawnItemChance;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;


        weaponsRotationSpeed = (Random.Range(0, 2) == 1) ? weaponsRotationSpeed : -weaponsRotationSpeed; //Different weapon rotation direction
        //Sync weapon
        if (weaponsRotationSpeed < 0) weapons.transform.localScale = new Vector3(-weapons.transform.localScale.x, weapons.transform.localScale.y, weapons.transform.localScale.z);

        foreach (Rigidbody rb in rigidbodyParts) {
            rb.isKinematic = true;
        }
    }
    private void Update() {
        weapons.Rotate(Vector3.up * weaponsRotationSpeed * Time.deltaTime);
        
        //mesh.rotation = Quaternion.Lerp(mesh.rotation, Quaternion.Euler(new Vector3(0, player.))
        if (Vector3.Distance(player.position, transform.position) < Distance) {
            agent.SetDestination(player.position);
            mesh.LookAt(new Vector3(player.position.x, mesh.position.y, player.position.z));
        }   
    }
    public void Kill() {
        character.parent = null;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Instantiate(destroyedFloater, pos, Quaternion.identity);
        foreach (Rigidbody rb in rigidbodyParts) {
            rb.isKinematic = false;
            rb.AddForce(-rb.transform.forward * explodeForce);
        }
    }
}
