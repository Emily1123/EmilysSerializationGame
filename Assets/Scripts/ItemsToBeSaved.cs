using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemsToBeSaved : MonoBehaviour
{
    [HideInInspector] public List<GameData> gameEntries = new List<GameData>();

    public GameObject player;

    public Action save;

    public void SaveData()
    {
        GameData dataEntryToAdd = new GameData
        {
            savePos = player.transform.position,
            saveRotation = player.transform.rotation
        };

        gameEntries.Add(dataEntryToAdd);

        if (save != null) save();
    }

    public SerializableData Save()
    {
        return new SerializableData { entries = gameEntries.ToArray() };
    }
}

[Serializable]
public class SerializableData
{
    public GameData[] entries;
}