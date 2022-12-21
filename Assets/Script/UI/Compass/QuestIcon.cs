using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIcon : MonoBehaviour
{
    Compass compass;

    // Start is called before the first frame update
    void Start()
    {
        compass = GetComponentInParent<Compass>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (QuestMarker marker in compass.questMarkers)
        {
            if (marker.questCompleted == true)
            {
                if(marker.name + "QuestMarker" == this.gameObject.name)
                {
                    Destroy(this.gameObject);
                    compass.questMarkers.Remove(marker);
                }
            }
        }
    }
}
