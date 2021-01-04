using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //[SerializeField] private GameObject continueButton;

    [Space]
    [SerializeField] private TextMeshProUGUI coinsCountText;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start() {
        //if (PlayerPrefs.HasKey("LastLevel")) continueButton.SetActive(true); else continueButton.SetActive(false);
        coinsCountText.text = PlayerPrefs.GetInt("CollectedCoins").ToString();
        levelText.text = "Level " + PlayerPrefs.GetInt("LastLevel").ToString();
    }
    public void NewGame() {
        PlayerPrefs.DeleteKey("LastLevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Continue() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));
    }
}
