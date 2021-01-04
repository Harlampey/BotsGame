using UnityEngine;

public class LootBox : MonoBehaviour {
    public static float spawnForce = 250f;

    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject destroyedBox;

    [Header("Optional")]
    [SerializeField] private byte itemID;
    [SerializeField] private bool emptyBox;

    /*
     * Item IDs:
     * 1: Multiple Swords
     * 2: Rotation Speed
     * 3: Long Weapon
     * 4: Coin
     * 5: Heart
     */
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerWeapon") {
            SpawnItem();
            Destroy(gameObject);
        }
    }

    private void SpawnItem() {
        if (itemID == 0 && !emptyBox ) {
            int id = Random.Range(0, items.Length);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[id], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
        } else if (!emptyBox) {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[itemID - 1], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
        } else {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[Random.Range(4, 6)], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
        }
        Vector3 boxPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(destroyedBox, boxPos, Quaternion.identity);
    }
}
