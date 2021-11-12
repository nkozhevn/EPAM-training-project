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
    public int[] skills = { 0, 0, 0 };
    public int[] weapons = { 0, 0, 0 };
 
    public Data(GameData gameData)
    {
        difficulty = gameData.difficulty;
        level = gameData.level;
        maxHealth = gameData.maxHealth;
        currentHealth = gameData.currentHealth;
        playerLevel = gameData.playerLevel;
        playerLevelPoints = gameData.playerLevelPoints;

        /*int i = 0;
        foreach(bool skill in gameData.skills)
        {
            if(skill)
            {
                skills[i] = 1;
            }
            else
            {
                skills[i] = 0;
            }
            i++;
        }*/
        //for(int i = 0; i < GameLoop.Instance.upgradeFinders.Count; i++)
        //{
        //    if(gameData.skills[GameLoop.Instance.upgradeFindersNames[i]])
        //    {
        //        skills[i] = 1;
        //    }
        //    else
        //    {
        //        skills[i] = 0;
        //    }
        //}

        //for(int i = 0; i < GameLoop.Instance.weaponFinders.Count; i++)
        //{
        //    if(gameData.weapons[GameLoop.Instance.weaponFindersNames[i]])
        //    {
        //        weapons[i] = 1;
        //    }
        //    else
        //    {
        //        weapons[i] = 0;
        //    }
        //}
    }
}
