using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_door : MonoBehaviour
{
    public bool faithOnPillar;
    public bool hopeOnPillar;
    public bool charityOnPillar;

    // Start is called before the first frame update
    void Start()
    {
        faithOnPillar = false;
        hopeOnPillar = false;
        charityOnPillar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(faithOnPillar && hopeOnPillar && charityOnPillar)
        {
            Compass compass = GameObject.Find("Compass").GetComponent<Compass>();
            compass.CompleteQuestMarker("FinalDoor");
            this.gameObject.SetActive(false);
        }
    }
}
