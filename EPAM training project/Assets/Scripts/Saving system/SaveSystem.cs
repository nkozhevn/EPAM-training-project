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
        //FileStream stream = new FileStream(path, FileMode.Create);
        using(FileStream stream = new FileStream(path, FileMode.Create))
        {
            Data data = new Data(gameData);
            formatter.Serialize(stream, data);
        }

        /*Data data = new Data(gameData);
        formatter.Serialize(stream, data);
        stream.Close();*/
    }

    public static Data LoadPlayer()
    {
        string path = Application.persistentDataPath + "/game.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(path, FileMode.Open);
            Data data;
            using(FileStream stream = new FileStream(path, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as Data;
            }

            /*Data data = formatter.Deserialize(stream) as Data;
            stream.Close();*/
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
