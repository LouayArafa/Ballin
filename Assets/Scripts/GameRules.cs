using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rules")]

public class GameRules : ScriptableObject
{
    public int PlayersCount;
    public int RoundsCout;

    public List<string> PlayerNames = new List<string>();
}
