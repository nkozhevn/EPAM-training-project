using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
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

    public void SetGameStart(int value)
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
        level = GameLoop.Instance.firstLevelName;
        playerLevel = 0;
        playerLevelPoints = 0;
        items[GameLoop.Instance.itemNames[0]] = true;
        for(int i = 1; i < GameLoop.Instance.itemNames.Count; i++)
        {
            items[GameLoop.Instance.itemNames[i]] = false;
        }
    }

    public void SetLevelEnd()
    {
        level = GameLoop.Instance.nextLevelName;
        maxHealth = GameLoop.Instance.Player.Health.maxHealthPoints;
        currentHealth = GameLoop.Instance.Player.Health.HealthPoints;
        playerLevel = GameLoop.Instance.Player.Level.PlayerLevel;
        playerLevelPoints = GameLoop.Instance.Player.Level.LevelPoints;
        for(int i = 0; i < GameLoop.Instance.itemNames.Count; i++)
        {
            if(GameLoop.Instance.Player.Inventory.GotCheck(GameLoop.Instance.itemNames[i]))
            {
                items[GameLoop.Instance.itemNames[i]] = true;
            }
        }
    }
    
    public void SetGameEnd(string firstLevelName)
    {
        level = firstLevelName;
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

        for(int i = 0; i < GameLoop.Instance.itemNames.Count; i++)
        {
            if(data.items[i] == 0)
            {
                items[GameLoop.Instance.itemNames[i]] = false;
            }
            else
            {
                items[GameLoop.Instance.itemNames[i]] = true;
            }
        }
    }
}
