using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance{ get; private set; }
    [SerializeField] public string levelName;
    [SerializeField] public string firstLevelName;
    [SerializeField] public string nextLevelName;
    [SerializeField] private UIController uIController;
    [SerializeField] private TriggerObjects finish;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] public List<UpgradeFinder> upgradeFinders;
    [SerializeField] public List<string> upgradeFindersNames;
    [SerializeField] public List<WeaponFinder> weaponFinders;
    [SerializeField] public List<string> weaponFindersNames;
    [SerializeField] private GameData gameData;
    [SerializeField] private Player player;
    public bool gameIsPaused = false;
    public bool objective = false;
    public GameData GameData
    {
        get
        {
            return gameData;
        }
        private set
        {
            gameData = value;
        }
    }
    public Player Player => player;

    private void Awake()
    {
        Instance = this;

        GameData.LoadGame();
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if(Player != null)
        {
            Player.PlayerDied += OnPlayerDied;
        }
    }

    private void Update()
    {
        if(finish != null)
        {
            if(finish.IsActivated && objective)
            {
                OnFinish();
            }
        }
    }

    private void OnPlayerDied()
    {
        //PlayerPrefs.SetString("Level", firstLevelName);
        //GameData.level = firstLevelName;
        GameData.SetGameEnd(firstLevelName);
        GameData.SaveGame();
        uIController.GameOver();
    }

    public void SetDifficulty(int value)
    {
        // switch(value)
        // {
        //     case 0:
        //         /*PlayerPrefs.SetInt("Difficulty", 0);
        //         PlayerPrefs.SetInt("MaxHealth", 20);
        //         PlayerPrefs.SetInt("CurrentHealth", 20);*/
        //         GameData.difficulty = 0;
        //         GameData.maxHealth = 20;
        //         GameData.currentHealth = 20;
        //         break;
        //     case 1:
        //         /*PlayerPrefs.SetInt("Difficulty", 1);
        //         PlayerPrefs.SetInt("MaxHealth", 10);
        //         PlayerPrefs.SetInt("CurrentHealth", 10);*/
        //         GameData.difficulty = 1;
        //         GameData.maxHealth = 10;
        //         GameData.currentHealth = 10;
        //         break;
        // }
        // /*PlayerPrefs.SetString("Level", firstLevelName);
        // PlayerPrefs.SetInt("PlayerLevel", 0);
        // PlayerPrefs.SetInt("PlayerLevelPoints", 0);
        // PlayerPrefs.SetInt("Shotgun", 0);
        // PlayerPrefs.SetInt("Rifle", 0);
        // PlayerPrefs.SetInt("Granade", 0);*/
        // GameData.level = firstLevelName;
        // GameData.playerLevel = 0;
        // GameData.playerLevelPoints = 0;
        // /*foreach(bool skill in GameData.skills)
        // {
        //     skill = false;
        // }*/
        // for(int i = 0; i < upgradeFinders.Count; i++)
        // {
        //     GameData.skills[upgradeFindersNames[i]] = false;
        // }
        // GameData.weapons[weaponFindersNames[0]] = true;
        // for(int i = 1; i < weaponFinders.Count; i++)
        // {
        //     GameData.weapons[weaponFindersNames[i]] = false;
        // }
        GameData.SetGameStart(value);
        GameData.SaveGame();
    }

    private void OnFinish()
    {
        /*PlayerPrefs.SetString("Level", nextLevelName);
        PlayerPrefs.SetInt("MaxHealth", Player.Health.maxHealthPoints);
        PlayerPrefs.SetInt("CurrentHealth", Player.Health.HealthPoints);
        PlayerPrefs.SetInt("PlayerLevel", Player.level.PlayerLevel);
        PlayerPrefs.SetInt("PlayerLevelPoints", Player.level.LevelPoints);*/
        // GameData.level = nextLevelName;
        // GameData.maxHealth = Player.Health.maxHealthPoints;
        // GameData.currentHealth = Player.Health.HealthPoints;
        // GameData.playerLevel = Player.level.PlayerLevel;
        // GameData.playerLevelPoints = Player.level.LevelPoints;
        // for(int i = 0; i < upgradeFinders.Count; i++)
        // {
        //     if(upgradeFinders[i].skillGot)
        //     {
        //         //PlayerPrefs.SetInt(upgradeFinders[i].upgradeName, 1);
        //         GameData.skills[upgradeFindersNames[i]] = true;
        //     }
        // }
        // for(int i = 0; i < weaponFinders.Count; i++)
        // {
        //     if(weaponFinders[i].weaponGot)
        //     {
        //         GameData.weapons[weaponFindersNames[i]] = true;
        //     }
        // }
        GameData.SetLevelEnd();
        GameData.SaveGame();
        uIController.Finish();
    }

    private void OnDestroy()
    {
        if(Player != null)
        {
            Player.PlayerDied -= OnPlayerDied;
        }
    }
}
