using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderwin : MonoBehaviour
{
    public string leaveGame = "Menu";
    public string nextGame = "1.InsideJail";
    public GameObject winToshow;

    public bool h_showWin = false;
    bool showWinEvent = true;

    public FirstPersonController fps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && showWinEvent)
        {
            winToshow.gameObject.SetActive(true);
            h_showWin = true;
            Time.timeScale = 0f;
            fps.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void next()
    {
        SceneManager.LoadScene(nextGame);
        Time.timeScale = 1f;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Leave()
    {
        SceneManager.LoadScene(leaveGame);
        Time.timeScale = 1f;
        fps.enabled = true;
    }
}
