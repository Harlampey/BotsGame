using UnityEngine;

public class B_longWeapon : Bonus{
    public override void PickItem(GameObject other) {
        Transform weaponsGroup = other.transform.parent.GetComponent<WeaponsRotation>().WeaponsGroup;
        weaponsGroup.localScale = new Vector3(weaponsGroup.localScale.x + 0.15f, 1, weaponsGroup.localScale.z + 0.15f);
    }
}
