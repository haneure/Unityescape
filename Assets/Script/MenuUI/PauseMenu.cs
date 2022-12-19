using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string leaveGame = "Menu";
    public bool GameIsPaused = false;
    public FirstPersonController fps;

    public GameObject pauseMenuUI;
    GameObject compassUI;
    GameObject uiInventory;
    // // Start is called before the first frame update
    void Start()
    {
        compassUI = GameObject.Find("CompassUI");
        uiInventory = GameObject.Find("UI_Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                compassUI.SetActive(true);
                uiInventory.SetActive(true);
                Resume();
            }
            else{
                compassUI.SetActive(false);
                uiInventory.SetActive(false);
                Pause();
            }
        }
    }

    public void Resume ()
    {
        compassUI.SetActive(true);
        uiInventory.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        fps.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Leave()
    {
        SceneManager.LoadScene(leaveGame);
        Time.timeScale = 1f;
        GameIsPaused = false;
        fps.enabled = true;
        pauseMenuUI.SetActive(false);
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
        fps.enabled = true;
        pauseMenuUI.SetActive(false);
    }

}
