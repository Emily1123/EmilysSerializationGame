using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Savable Items", menuName = "Savable")]
public class SavingAllData : ScriptableObject
{
    public List<GameData> entries = new List<GameData>();
}
