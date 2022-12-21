using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator anim;
    private string levelToLoad;
    private int levelToLoadIndex;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToNextLevelIndex()
    {
        FadeToLevelIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevelIndex(int index) {
        this.gameObject.SetActive(true);
        anim = GameObject.Find("NextLevelTransition").GetComponent<Animator>();
        levelToLoadIndex = index;
        anim.SetTrigger("FadeOut");
    }

    public void FadeToLevel(string levelName)
    {
        this.gameObject.SetActive(true);
        anim = GameObject.Find("LevelChanger").GetComponent<Animator>();
        levelToLoad = levelName;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OnFadeCompleteIndex()
    {
        SceneManager.LoadScene(levelToLoadIndex);
    }
}
