using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public string playGame1 = "1.InsideJail";
    public string playGame2 = "2.OutsideJail";
    public string playGame3 = "3.DownstairJail";

    // public SceneFader fader;
    
    // public void Select (string levelName)
    // {
    //     fader.FadeTo(levelName);
    // }

    // int levelReached = PlayerPrefs.GetInt("levelReached", 1);

    // public Button[] levelButtons;

    // void Start ()
    // {
    //     for (int i = 0; i < levelButtons.length; i++)
    //     {
    //         if(i + 1 < levelReached)
    //         {
    //             levelButtons[i].interactable = false;
    //         }
    //     }
    // }

    public void Play1()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1);
    }

    public void Play2()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame2);
    }

    public void Play3()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame3);
    }

    public void Quit()
    {
        Debug.Log("Exciting....");
        Application.Quit();
    }
}
