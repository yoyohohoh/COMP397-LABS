using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
class PlayerData
{
    public string position;
}

[System.Serializable]
public class SaveGameManager
{
    private static SaveGameManager m_instance = null;
    private SaveGameManager() { }
    public static SaveGameManager Instance()
    {
        return m_instance ??= new SaveGameManager();
    }

    public void SaveGame(Transform playerTransform)
    {
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/MySaveData.txt");

        var data = new PlayerData
        {
            position = JsonUtility.ToJson(playerTransform.position)
        };
        binaryFormatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game Data Save");
    }

}