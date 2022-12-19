using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string leaveGame = "Menu";
    public static bool GameIsPaused = false;
    public FirstPersonController fps;
    public float holdtime;

    public GameObject pauseMenuUI;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(holdtime>0)
        {
            holdtime -= Time.unscaledDeltaTime;
        }
        if((Input.GetKeyDown(KeyCode.Escape) && !Application.isMobilePlatform))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton4) && Application.isMobilePlatform)
        {
            holdtime = 5f;
        }

        if(holdtime>0 && (Input.GetKey(KeyCode.JoystickButton5) && Application.isMobilePlatform))
        {
            if(Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if(GameIsPaused)
                {
                    Resume();
                }
                else{
                    Pause();
                }
            }
        }
    }

    public void Resume ()
    {
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
