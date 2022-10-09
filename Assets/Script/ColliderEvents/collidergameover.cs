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
        if(other.gameObject.name == "Player" && showGameoEvent)
        {
            gameOverToshow.gameObject.SetActive(true);
            h_showGameO = true;
            Time.timeScale = 0f;
            fps.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(retryGame);
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
