using UnityEngine;
using UnityEngine.UI;

public class EnemyIco : MonoBehaviour {
    [SerializeField] private Image avatar;
    [SerializeField] private GameObject mark;
    public void Disable() {
        avatar.color = new Color(255, 2555, 255, 0.5f);
        mark.SetActive(true);
    }
}
