
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDoor : Door {
    public override void Base() {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey("LastLevel");
        
    }
}
