using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string position;
}

[System.Serializable]
public class SaveGameManager
{
    private string _filePath = Application.persistentDataPath + "/MySaveData.txt";
    private static SaveGameManager m_instance = null;
    private SaveGameManager() { }
    public static SaveGameManager Instance()
    {
        return m_instance ??= new SaveGameManager();
    }

    public void SaveGame(Transform playerTransform)
    {
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(_filePath);

        var data = new PlayerData
        {
            position = JsonUtility.ToJson(playerTransform.position)
        };
        binaryFormatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game Data Save");
    }

    public PlayerData LoadGame()
    {
        if (!File.Exists(_filePath)) { return null; }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(_filePath, FileMode.Open);
        PlayerData data = formatter.Deserialize(file) as PlayerData;
        file.Close();
        return data;
    }

    
}