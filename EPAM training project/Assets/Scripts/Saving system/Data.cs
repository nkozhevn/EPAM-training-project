using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int difficulty;
    public string level;
    public int maxHealth;
    public int currentHealth;
    public int playerLevel;
    public int playerLevelPoints;
    public int[] items = { 0, 0, 0, 0, 0, 0 };
 
    public Data(GameData gameData)
    {
        difficulty = gameData.difficulty;
        level = gameData.level;
        maxHealth = gameData.maxHealth;
        currentHealth = gameData.currentHealth;
        playerLevel = gameData.playerLevel;
        playerLevelPoints = gameData.playerLevelPoints;

        for(int i = 0; i < LevelController.Instance.itemNames.Count; i++)
        {
            if(gameData.items[LevelController.Instance.itemNames[i]])
            {
                items[i] = 1;
            }
            else
            {
                items[i] = 0;
            }
        }
    }
}
