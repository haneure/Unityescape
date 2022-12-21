using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

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
        if(Application.isMobilePlatform)
        {
            InitXR();
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        currentStageName = data.currentStageName;
        SceneManager.LoadScene(data.currentStageName);
    }

    public IEnumerator InitXR()
    {
        yield return  XRGeneralSettings.Instance.Manager.InitializeLoader();
    }
}
