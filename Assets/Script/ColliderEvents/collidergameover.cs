using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidergameover : MonoBehaviour
{
    public string leaveGame = "Menu";
    public string retryGame;
    public GameObject gameOverToshow;
    
    public bool h_showGameO = false;
    bool showGameoEvent = true;

    public FirstPersonController fps;

    public PauseMenu pauseMenu;

    GameObject compassUI;
    GameObject uiInventory;
    GameObject questUI;
    GameObject dialogue;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("UI").GetComponentInChildren<PauseMenu>();
        retryGame = SceneManager.GetActiveScene().name;
        compassUI = GameObject.Find("CompassUI");
        uiInventory = GameObject.Find("UI_Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        questUI = GameObject.Find("QuestUI");
        dialogue = GameObject.Find("Dialogue");
    }

    public void showGameOverUI() {
        if (compassUI != null)
        {
            compassUI.SetActive(false);
        }
        if (questUI != null)
        {
            questUI.SetActive(false);
        }
        if (dialogue != null)
        {
            dialogue.SetActive(false);
        }
        uiInventory.SetActive(false);
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
