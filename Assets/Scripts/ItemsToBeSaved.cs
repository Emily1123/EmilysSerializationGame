using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemsToBeSaved : MonoBehaviour
{
    [HideInInspector] public List<GameData> gameEntries = new List<GameData>();
    public List<ButtonState> buttons = new List<ButtonState>();

    public GameObject player;

    public Action save;

    public string SaveData()
    {

        JsonArray jsonArray = new JsonArray
        {
            jsons = new string[buttons.Count + 1]
        };

        GameData dataEntryToAdd = new GameData
        {
            savePos = player.transform.position,
            saveRotation = player.transform.rotation
        };

        jsonArray.jsons[0] = JsonUtility.ToJson( dataEntryToAdd );
        // gameEntries.Add(dataEntryToAdd);

        // if (save != null) save();


        for( int index = 0; index < buttons.Count; index++ )
        {
            string buttonJson = buttons[index].SaveMe();
            jsonArray.jsons[index + 1] = buttonJson;
        }

        string allJson = JsonUtility.ToJson( jsonArray );

        return allJson;
    }

    public void Load( string allJson )
    {
        JsonArray jsonArray = JsonUtility.FromJson<JsonArray>( allJson );

        for( int index = 0; index < jsonArray.jsons.Length; index++ )
        {
            if( index == 0 )
            {
                GameData playerData = JsonUtility.FromJson<GameData>( jsonArray.jsons[index] );
                player.transform.position = playerData.savePos;
                player.transform.rotation = playerData.saveRotation;
            }
            else
            {
                buttons[index - 1].LoadMe( jsonArray.jsons[index] );
            }
        }
    }

    // public SerializableData Save()
    // {
    //     return new SerializableData { entries = gameEntries.ToArray() };
    // }
}

[Serializable]
public class SerializableData
{
    public GameData[] entries;
}

public class JsonArray
{
    public string[] jsons;
}