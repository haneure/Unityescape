using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercoba : MonoBehaviour
{
    public int level;
    public string currentStageName;


    public void SavePlayer()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentStageName = scene.name;
        Debug.Log("save");
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        currentStageName = data.currentStageName;
        SceneManager.LoadScene(data.currentStageName);
    }
}
