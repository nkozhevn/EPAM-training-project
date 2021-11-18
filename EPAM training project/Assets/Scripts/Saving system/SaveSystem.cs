using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.data";
        using(FileStream stream = new FileStream(path, FileMode.Create))
        {
            Data data = new Data(gameData);
            formatter.Serialize(stream, data);
        }
    }

    public static Data LoadPlayer()
    {
        string path = Application.persistentDataPath + "/game.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Data data;
            using(FileStream stream = new FileStream(path, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as Data;
            }

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
