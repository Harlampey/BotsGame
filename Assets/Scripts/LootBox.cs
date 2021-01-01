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
     */
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerWeapon") {
            SpawnItem();
            Destroy(gameObject);
        }
    }

    private void SpawnItem() {
        //&& !Level.isAdditionalWeaponPicked && !Level.isFastRotationPicked && !Level.isLongWeaponPicked
        if (itemID == 0 && !emptyBox ) {
            int id = Random.Range(0, items.Length);
            //while (id == 1 && !Level.isAdditionalWeaponPicked || id == 2 && !Level.isFastRotationPicked || id == 3 && !Level.isLongWeaponPicked) {
            //    id = Random.Range(0, items.Length);
            //}
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[id], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
            //if (id != 4) RegisterItemAsPicked(id);
        } else if (!emptyBox) {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[itemID - 1], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
            //RegisterItemAsPicked(itemID);
        } else {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[4], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
        }
        Vector3 boxPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(destroyedBox, boxPos, Quaternion.identity);
    }
    private void RegisterItemAsPicked(int itemID) {
        switch (itemID) {
            case 1:
                Level.isAdditionalWeaponPicked = true;
                break;
            case 3:
                Level.isAdditionalWeaponPicked = true;
                break;
            case 2:
                Level.isAdditionalWeaponPicked = true;
                break;
        }
    }
}
