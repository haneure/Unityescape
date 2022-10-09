using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidergameover : MonoBehaviour
{
    public string leaveGame = "Menu";
    public string retryGame = "Old Sea Port";
    public GameObject gameOverToshow;
    
    public bool h_showGameO = false;
    bool showGameoEvent = true;

    public FirstPersonController fps;

    public PauseMenu pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("UI").GetComponentInChildren<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && showGameoEvent)
        {
            showGameOverUI();
        }
    }

    public void showGameOverUI() {
        gameOverToshow.gameObject.SetActive(true);
        h_showGameO = true;
        Time.timeScale = 0f;
        fps.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void retry()
    {
        fps.enabled = true;
        gameOverToshow.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.Pause();
        pauseMenu.Resume();
        SceneManager.LoadScene(retryGame);
    }

    public void Leave()
    {
        gameOverToshow.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fps.enabled = true;
        SceneManager.LoadScene(leaveGame);
    }
}
