using UnityEngine;

public class B_additionalWeapon : Bonus {
    public override void PickItem(GameObject other) {
        other.transform.parent.GetComponent<WeaponsRotation>().ShowAdditionalWeapon();
    }
}
