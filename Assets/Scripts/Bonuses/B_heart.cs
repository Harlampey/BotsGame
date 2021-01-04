using UnityEngine;

public class B_heart : Bonus {
    public override void PickItem(GameObject other) {
        other.transform.parent.GetComponent<PlayerMovement>().AddHeal();
    }
}
