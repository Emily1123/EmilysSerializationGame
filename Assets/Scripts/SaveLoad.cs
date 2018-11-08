using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    const string FILE_NAME = "GameSaveData.txt";

    public ItemsToBeSaved items;

    void Start() {
        LoadGameData();
    }

    public void LoadGameData()
    {
        string pathToLoad = System.IO.Path.Combine(Application.streamingAssetsPath, FILE_NAME);
        FileInfo savedEntries = new FileInfo(pathToLoad);

        if (savedEntries.Exists)
        {
            string jsonObj = File.ReadAllText(pathToLoad);
            items.Load( jsonObj );
            // items.gameEntries = new List<GameData>(JsonUtility.FromJson<SerializableData>(jsonObj).entries);
        }
    }

    public void SaveGameData()
    {
        string jsonObj = items.SaveData();

        string pathToSave = System.IO.Path.Combine(Application.streamingAssetsPath, FILE_NAME);

        DirectoryInfo streamingAssetsFolder = new DirectoryInfo(Application.streamingAssetsPath);
        if (!streamingAssetsFolder.Exists) streamingAssetsFolder.Create();

        File.WriteAllText(pathToSave, jsonObj);
    }
}
