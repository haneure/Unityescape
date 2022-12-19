using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public LevelChanger levelChanger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLevel(string levelName) {
        levelChanger.FadeToLevel(levelName);    
    }

    public void NextLevel()
    {
        levelChanger.FadeToNextLevelIndex();
    }
}
