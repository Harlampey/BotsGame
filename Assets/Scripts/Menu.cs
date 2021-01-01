using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField] private GameObject continueButton;

    private void Start() {
        if (PlayerPrefs.HasKey("LastLevel")) continueButton.SetActive(true); else continueButton.SetActive(false);
    }
    public void NewGame() {
        PlayerPrefs.DeleteKey("LastLevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Continue() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));
    }
}
