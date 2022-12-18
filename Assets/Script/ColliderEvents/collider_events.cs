using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collider_events : MonoBehaviour
{
    public UnityEvent onInteract;
    bool triggerGraveyard = false;

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
        if (other.gameObject.name == "Player")
        {
            if (triggerGraveyard == false)
            {
                if (onInteract != null)
                {
                    onInteract.Invoke();
                    triggerGraveyard = true;
                }
            }
        }
    }

}
