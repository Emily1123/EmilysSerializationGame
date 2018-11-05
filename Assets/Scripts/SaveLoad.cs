using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    private string fileName = "GameData.json";
    private string filePath;

    private static SaveLoad _instance;
    public SaveLoad Instance
    {
        get {return _instance;}
    }

    GameData gameData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(_instance == null)
        {
            _instance = new SaveLoad();
        }

        if (gameData == null)
        {
            gameData = new GameData();
        }

        filePath = Path.Combine(Application.dataPath, fileName);

        Debug.Log(filePath);
    }

    public void LoadGameData()
    {
        string json;

        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("File is missing: " + filePath);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        File.WriteAllText(filePath, json);
    }
}
