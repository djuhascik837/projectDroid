using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    
    public static void SaveData(GlobalCoins playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "playerData.data");
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerData);

        //Insert into a file
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "playerData.data");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } 
        else
        {
            Debug.LogError("Save file not found path: " + path);
            return null;
        }
    }

}
