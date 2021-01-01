using UnityEngine;

public class B_fastRotation : Bonus {
    public override void PickItem(GameObject other) {
        other.transform.parent.GetComponent<WeaponsRotation>().RotationSpeed += 80;
    }
}
