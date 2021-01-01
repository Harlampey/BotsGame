using UnityEngine;
using System.Collections;

public class EnemyHitCollider : MonoBehaviour {
    private float spawnForce = 250f;

    [SerializeField] private GameObject[] items;
    private EnemyMovement enemyMovement;
    private int spawnItemChance;
    private float maxHealth;

    [SerializeField] private GameObject canvas;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private float maxHealthBarSize = 8;
    [SerializeField]private float Health = 3;

    [Space]
    [SerializeField] private GameObject character;
    [SerializeField] private Material[] charaterMaterials;

    [Space]
    [SerializeField] private GameObject disk;
    [SerializeField] private Material diskMaterial;

    [Space]
    [SerializeField] private Material whiteHitMaterial;
    [SerializeField] private float whiteMatDuration;
    

    private void Start() {
        maxHealth = Health;
        canvas.SetActive(false);
        enemyMovement = GetComponentInParent<EnemyMovement>();
        spawnItemChance = enemyMovement.spawnItemChance;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerWeapon") {
            CheckHealth();
        }
    }
    private void CheckHealth() {
        canvas.SetActive(true);
        Health -= 1;
        if (Health <= 0) {
            Kill();
        } else {
            StartCoroutine(displayHit());
            healthBar.sizeDelta = new Vector2(Health*(maxHealthBarSize / maxHealth), 0);
            enemyMovement.animator.Play("EnemyHit");
        }
    }
    private void Kill() {
        if (Random.Range(0, 100) <= spawnItemChance) {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject spawnedItem = Instantiate(items[Random.Range(0, items.Length)], pos, Quaternion.identity);
            spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * spawnForce);
        }


        enemyMovement.Kill();
        Destroy(transform.parent.gameObject);
        Level.CheckEnemiesCount();
    }

    private IEnumerator displayHit() {
        MeshRenderer diskRenderer = disk.GetComponent<MeshRenderer>();
        SkinnedMeshRenderer characterRenderer = character.GetComponent<SkinnedMeshRenderer>();

        diskRenderer.material = whiteHitMaterial;
        characterRenderer.material = whiteHitMaterial;

        yield return new WaitForSeconds(whiteMatDuration);

        diskRenderer.material = diskMaterial;
        characterRenderer.material = charaterMaterials[0];
        //characterRenderer.materials[1] = charaterMaterials[1];
    }
}
