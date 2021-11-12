using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int difficulty;
    public string level;
    public int maxHealth;
    public int currentHealth;
    public int playerLevel;
    public int playerLevelPoints;
    public Dictionary<string, bool> skills = new Dictionary<string, bool>
    {
        {"Granade", false},
        {"Fire", false},
        {"Shield", false}
    };
    public Dictionary<string, bool> weapons = new Dictionary<string, bool>
    {
        {"Pistol", true},
        {"Shotgun", false},
        {"Rifle", false}
    };
    /*public int Difficulty => _difficulty;
    public string level => _level;
    public int maxHealth => _maxHealth;
    public int currentHealth => _currentHealth;
    public int playerLevel => _playerLevel;
    public int playerLevelPoints => _playerLevelPoints;
    public Dictionary<string, bool> skills => _skills;*/

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

        /*int i = 0;
        foreach(bool skill in skills)
        {
            if(data.skills[i] == 0)
            {
                skill = false;
            }
            else
            {
                skill = true;
            }
        }*/
        for(int i = 0; i < GameLoop.Instance.upgradeFinders.Count; i++)
        {
            if(data.skills[i] == 0)
            {
                skills[GameLoop.Instance.upgradeFindersNames[i]] = false;
            }
            else
            {
                skills[GameLoop.Instance.upgradeFindersNames[i]] = true;
            }
        }

        for(int i = 0; i < GameLoop.Instance.weaponFinders.Count; i++)
        {
            if(data.weapons[i] == 0)
            {
                weapons[GameLoop.Instance.upgradeFindersNames[i]] = false;
            }
            else
            {
                skills[GameLoop.Instance.upgradeFindersNames[i]] = true;
            }
        }
    }
}
