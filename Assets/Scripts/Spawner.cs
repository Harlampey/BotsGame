using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private bool canSpawn;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float interval, minDelay, maxDelay;

    private GameObject spawnedObject;
    [SerializeField] private Vector3[] positions;

    private void Start() {
        transform.position = positions[Random.Range(0, positions.Length)];
        canSpawn = true;
        Invoke("StartSpawning", Random.Range(minDelay, maxDelay));
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer != 10)
            canSpawn = false;

        Debug.Log(other.gameObject.name);
    }

    private IEnumerator Spawn() {
        while (true) {
            if (canSpawn) {
                Instantiate(spawnObject, transform.position, Quaternion.identity);
            }
            transform.position = positions[Random.Range(0, positions.Length)];
            canSpawn = true;
            yield return new WaitForSeconds(interval);
        }
    }
    private void StartSpawning() {
        StartCoroutine(Spawn());
    }
}
