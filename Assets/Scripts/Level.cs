using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class Level : MonoBehaviour {
    [SerializeField] private GameObject enemiesFolder, gamePanel, wonPanel, losePanel;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private TextMeshProUGUI levelText, coinsCountText;

    public static Level level;
    public static bool isAdditionalWeaponPicked, isLongWeaponPicked, isFastRotationPicked;


    private Dictionary<string, GameObject> enemyIconsGameObjects;
    private Dictionary<string, EnemyIco> enemyIcons;

    [Space]
    [Tooltip("0 - bandit\n1 - viking\n2 - rapper\n3 - samurai")]
    [SerializeField] private GameObject[] enemyIconsArray;


    private Dictionary<string, Transform> enemyIconsGroups;

    [Space]
    [Tooltip("0 - bandit\n1 - viking\n2 - rapper\n3 - samurai")]
    [SerializeField] private Transform[] enemyIconsGroupsArray;


    private EnemyIcons enemyIconsManager;

    private void Awake() {
        
    }
    private void Start() {
        InitializeDictionaries();
        enemyIconsManager = new EnemyIcons();

        level = this;
        isAdditionalWeaponPicked = isLongWeaponPicked = isFastRotationPicked = false;
        
        DisplayCoinsCount();
        levelText.text = SceneManager.GetActiveScene().name;
    }
    public static void CheckEnemiesCount() {
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
    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
    public static void AddEnemyIconToList(string enemyType) {
        Debug.Log(level.enemyIconsManager.dictionary.Count);

        GameObject spawnedObj = Instantiate(level.enemyIconsGameObjects[enemyType], level.enemyIconsGroups[enemyType]);
        level.enemyIconsGroups[enemyType].gameObject.SetActive(true);
        level.enemyIconsManager.dictionary[enemyType].Add(spawnedObj);
    }
    public static void RemoveEnemyIconFromList(string enemyType) {
        
        level.enemyIconsManager.dictionary[enemyType][0].GetComponent<EnemyIco>().Disable();
        level.enemyIconsManager.dictionary[enemyType].Remove(level.enemyIconsManager.dictionary[enemyType][0]);
    }
    
    private void InitializeDictionaries() {
        enemyIconsGameObjects = new Dictionary<string, GameObject>(4);
        enemyIconsGameObjects.Add("bandit", enemyIconsArray[0]);
        enemyIconsGameObjects.Add("viking", enemyIconsArray[1]);
        enemyIconsGameObjects.Add("rapper", enemyIconsArray[2]);
        enemyIconsGameObjects.Add("samurai", enemyIconsArray[3]);

        enemyIcons = new Dictionary<string, EnemyIco>(4);
        enemyIcons.Add("bandit", enemyIconsArray[0].GetComponent<EnemyIco>());
        enemyIcons.Add("viking", enemyIconsArray[1].GetComponent<EnemyIco>());
        enemyIcons.Add("rapper", enemyIconsArray[2].GetComponent<EnemyIco>());
        enemyIcons.Add("samurai", enemyIconsArray[3].GetComponent<EnemyIco>());

        enemyIconsGroups = new Dictionary<string, Transform>(4);
        enemyIconsGroups.Add("bandit", enemyIconsGroupsArray[0]);
        enemyIconsGroups.Add("viking", enemyIconsGroupsArray[1]);
        enemyIconsGroups.Add("rapper", enemyIconsGroupsArray[2]);
        enemyIconsGroups.Add("samurai", enemyIconsGroupsArray[3]);
    }
}
public class EnemyIcons {
    public List<GameObject> bandits, vikings, rappers, samurai;
    public Dictionary<string, List<GameObject>> dictionary;

    public EnemyIcons() {
        bandits = new List<GameObject>();
        vikings = new List<GameObject>();
        rappers = new List<GameObject>();
        samurai = new List<GameObject>();

        Debug.Log("Initialized");
        dictionary = new Dictionary<string, List<GameObject>>(4);
        dictionary.Add("bandit", bandits);
        dictionary.Add("viking", vikings);
        dictionary.Add("rapper", rappers);
        dictionary.Add("samurai", samurai);
    }
}