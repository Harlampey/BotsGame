using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    [SerializeField] private GameObject enemiesFolder, gamePanel, wonPanel, losePanel;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private Text enemiesCount, levelText, coinsCountText;

    public static Level level;
    public static bool isAdditionalWeaponPicked, isLongWeaponPicked, isFastRotationPicked;

    private void Start() {
        level = this;
        enemiesCount.text = (enemiesFolder.transform.childCount).ToString();
        isAdditionalWeaponPicked = isLongWeaponPicked = isFastRotationPicked = false;
        levelText.text = SceneManager.GetActiveScene().name;
        DisplayCoinsCount();
    }
    public static void CheckEnemiesCount() {
        Debug.Log(level.enemiesFolder.transform.childCount);
        level.enemiesCount.text = (level.enemiesFolder.transform.childCount - 1).ToString();
        if (level.enemiesFolder.transform.childCount == 1) {
            level.Won();
        }
    }
    public void Won() {
        foreach (GameObject door in doors) {
            door.SetActive(true);
        }
    }
    public static void Lose() {
        level.gamePanel.SetActive(false);
        level.losePanel.SetActive(true);
    }
    public static void DisplayCoinsCount() {
        level.coinsCountText.text = PlayerPrefs.GetInt("CollectedCoins").ToString();
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
