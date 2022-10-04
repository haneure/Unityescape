using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public string playGame = "Old Sea Port";
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void Play()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene(playGame);
    }

    public void Quit()
    {
        Debug.Log("Exciting....");
        Application.Quit();
    }
}
