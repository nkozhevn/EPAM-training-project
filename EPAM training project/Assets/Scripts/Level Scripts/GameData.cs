using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameData : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private string firstLevelName;
    [SerializeField] private string nextLevelName;
    [SerializeField] private string mainMenuSceneName;
    [SerializeField] private string gameThemeSoundName;
    [SerializeField] private string menuThemeSoundName;

    public string LevelName => levelName;
    public string FirstLevelName => firstLevelName;
    public string NextLevelName => nextLevelName;
    public string MainMenuSceneName => mainMenuSceneName;
    public string GameThemeSoundName => gameThemeSoundName;
    public string MenuThemeSoundName => menuThemeSoundName;

    [HideInInspector] public int difficulty;
    [HideInInspector] public string level;
    [HideInInspector] public int maxHealth;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int playerLevel;
    [HideInInspector] public int playerLevelPoints;

    public Dictionary<string, bool> items = new Dictionary<string, bool>
    {
        {"Pistol", true},
        {"Shotgun", false},
        {"Rifle", false},
        {"Granade", false},
        {"Fire", false},
        {"Shield", false}
    };

    public void SetGameStart(int value, string firstWeaponName)
    {
        switch(value)
        {
            case 0:
                difficulty = 0;
                maxHealth = 20;
                currentHealth = 20;
                break;
            case 1:
                difficulty = 1;
                maxHealth = 10;
                currentHealth = 10;
                break;
        }
        level = FirstLevelName;
        playerLevel = 0;
        playerLevelPoints = 0;

        foreach(string item in items.Keys.ToArray())
        {
            if(item == firstWeaponName)
            {
                items[item] = true;
            }
            else
            {
                items[item] = false;
            }
        }
        // items[LevelController.Instance.itemNames[0]] = true;
        // for(int i = 1; i < LevelController.Instance.itemNames.Count; i++)
        // {
        //     items[LevelController.Instance.itemNames[i]] = false;
        // }
    }

    public void SetLevelEnd()
    {
        level = NextLevelName;
        maxHealth = LevelController.Instance.Player.Health.maxHealthPoints;
        currentHealth = LevelController.Instance.Player.Health.HealthPoints;
        playerLevel = LevelController.Instance.Player.PlayerLevel.Level;
        playerLevelPoints = LevelController.Instance.Player.PlayerLevel.LevelPoints;

        foreach(InventoryItem item in LevelController.Instance.Player.Inventory.Items)
        {
            items[item.Name] = true;
        }
        // for(int i = 0; i < LevelController.Instance.itemNames.Count; i++)
        // {
        //     if(LevelController.Instance.Player.Inventory.GotCheck(LevelController.Instance.itemNames[i]))
        //     {
        //         items[LevelController.Instance.itemNames[i]] = true;
        //     }
        // }
    }
    
    public void SetGameEnd(string firstLevelName)
    {
        level = FirstLevelName;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        Data data = SaveSystem.LoadPlayer();

        difficulty = data.difficulty;
        level = data.level;
        maxHealth = data.maxHealth;
        currentHealth = data.currentHealth;
        playerLevel = data.playerLevel;
        playerLevelPoints = data.playerLevelPoints;

        int i = 0;
        foreach(string item in items.Keys.ToArray())
        {
            items[item] = data.items[i] == 1;
            i++;
        }
        // for(int i = 0; i < LevelController.Instance.itemNames.Count; i++)
        // {
        //     if(data.items[i] == 0)
        //     {
        //         items[LevelController.Instance.itemNames[i]] = false;
        //     }
        //     else
        //     {
        //         items[LevelController.Instance.itemNames[i]] = true;
        //     }
        // }
    }
}
