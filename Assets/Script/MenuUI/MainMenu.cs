using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public string playGame1_1 = "1.InsideJail";
    public string playGame1_2 = "2.OutsideJail";
    public string playGame1_3 = "3.DownstairJail";
    public string playGame1_4 = "4.DeepTunnelNew";
    public string playGame1_5 = "5.OldSeaPort";
    public string playGame1_6 = "5.MedievalPort";
    public string playGame1_7 = "7.Chapel";

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

    public void Play1_1()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_1);
    }

    public void Play1_2()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_2);
    }

    public void Play1_3()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_3);
    }

    public void Play1_4()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_4);
    }

    public void Play1_5()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_5);
    }

    public void Play1_6()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_6);
    }

    public void Play1_7()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame1_7);
    }



    public void Quit()
    {
        Debug.Log("Exciting....");
        Application.Quit();
    }
}
