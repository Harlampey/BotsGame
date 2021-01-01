using UnityEngine;
using System.Collections.Generic;

public class WeaponsRotation : MonoBehaviour {
    public Transform WeaponsGroup;
    [SerializeField] private List<GameObject> additionalWeapons;
    private byte collectedWeapons = 1;
    public float RotationSpeed;

    //We need change weapon1 & weapon2 rotation when player have 3 weapons. Result will be looks like star
    private Vector3 weapon1DefaultRotation, weapon2DefaultRotation, weapon1StarRotation, weapon2StarRotation;
    public Vector3 test;

    private void Start() {
        weapon1DefaultRotation = new Vector3(-90, 0, 0);
        weapon2DefaultRotation = new Vector3(-90, 180, 0);
        weapon1StarRotation = new Vector3(-90, -30, 0);
        weapon2StarRotation = new Vector3(-90, 210, 0);
    }
    private void Update() {
        WeaponsGroup.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

        //additionalWeapons[0].transform.eulerAngles = test;
    }
    public void SwitchRotation() {
        RotationSpeed *= -1;
    }
    public void ShowAdditionalWeapon() {
        if (collectedWeapons < additionalWeapons.Count) {
            additionalWeapons[collectedWeapons].SetActive(true);
            collectedWeapons++;

            if (collectedWeapons == 3) {
                additionalWeapons[0].transform.localRotation = Quaternion.Euler(weapon1StarRotation);
                additionalWeapons[1].transform.localRotation = Quaternion.Euler(weapon2StarRotation);
            } else {
                additionalWeapons[0].transform.localRotation = Quaternion.Euler(weapon1DefaultRotation);
                additionalWeapons[1].transform.localRotation = Quaternion.Euler(weapon2DefaultRotation);
            }
        }
    }
}
