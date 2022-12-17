using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public string currentStageName;

    public PlayerData (Playercoba player)
    {
        level = player.level;
        currentStageName = player.currentStageName;


    }
}
