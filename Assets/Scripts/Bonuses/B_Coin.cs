using UnityEngine;
public class B_Coin : Bonus {
    [SerializeField] private GameObject pickUpEffect;

    public override void PickItem(GameObject other) {
        Vector3 pos = transform.position + Vector3.up;
        Instantiate(pickUpEffect, pos, Quaternion.identity);
        PlayerPrefs.SetInt("CollectedCoins", PlayerPrefs.GetInt("CollectedCoins") + 1);
        Level.DisplayCoinsCount();
    }
}
