using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask InteractableLayerMask = 6;
    Interactable interactable;
    public Image interactImage;
    public Sprite defaultIcon, defaultInteractIcon;
    public Vector2 defaultIconSize, defaultInteractIconSize;
    public float rayLength;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.isMobilePlatform)
        {
            rayLength = 2.5f;
        }
        else
        {
            rayLength = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayLength, InteractableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                // Debug.Log(hit.collider.name);
                if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if(interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if(interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    }
                    else
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if(Application.isMobilePlatform)
                {
                    if (Input.GetButtonDown("Fire2"))
                    {
                        interactable.onInteract.Invoke();
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.onInteract.Invoke();
                    }
                }
            }
        }
        else
        {
            if(interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}
