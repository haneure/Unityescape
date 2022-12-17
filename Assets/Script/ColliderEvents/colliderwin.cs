using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderwin : MonoBehaviour
{
    public string leaveGame;
    public string nextGame;
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
            showWinUI();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(h_showWin == true){
                explore();
                h_showWin = false;
            } else {
                showWinUI();
            }
        }
    }

    public void showWinUI() {
        winToshow.gameObject.SetActive(true);
        h_showWin = true;
        Time.timeScale = 0f;
        fps.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void next()
    {
        Time.timeScale = 1f;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(nextGame);
    }

    public void Leave()
    {
        Time.timeScale = 1f;
        fps.enabled = true;
        SceneManager.LoadScene(leaveGame);
    }

    public void explore() {
        winToshow.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void gameClear() {
        winToshow.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
