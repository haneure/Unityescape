using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class DialogueComponent {
    public string charName;
    public TextMeshProUGUI textComponent;
    public RawImage character;
    public string lines;
    public Texture2D characterImg;
}

public class Dialogue : MonoBehaviour
{
    //public TextMeshProUGUI textComponent;
    //public RawImage mainCharacter;
    //public string[] lines;
    //public Texture2D[] character;
    public DialogueComponent[] dialogueComponents;
    public float textSpeed;

    private int index;
    private int textIndex;
    public GameObject UI_Inventory;

    public bool showScreenHint = false;
    public GameObject screenHint;
    public string quest;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        UI_Inventory = GameObject.Find("UI_Inventory");

        if (dialogueComponents[index].textComponent == null)
        {
            dialogueComponents[index].textComponent = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        }

        if (dialogueComponents[index].character == null)
        {
            dialogueComponents[index].character = GameObject.Find("CharacterImage").GetComponent<RawImage>();
        }

        Debug.Log(dialogueComponents[index].textComponent.text);
        dialogueComponents[index].textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (dialogueComponents[index].textComponent.text == dialogueComponents[index].lines)
            {
                index++;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueComponents[index].textComponent.text = dialogueComponents[index].lines;
            }
        }
    }

    void StartDialogue()
    {
        textIndex = 0;
        GameObject.Find("CharacterImage").GetComponent<RawImage>().texture = dialogueComponents[index].characterImg;
        UI_Inventory.SetActive(false);
        StartCoroutine(TypeLine());
    }

    void NextLine()
    { 
        if (index < dialogueComponents.Length)
        {
            if (textIndex < dialogueComponents[index].lines.Length - 1)
            {
                textIndex++;
                dialogueComponents[index].textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
            }
        } else
        {
            GameObject.Find("CharacterImage").SetActive(false);
            gameObject.SetActive(false);
            UI_Inventory.SetActive(true);
            if (quest != string.Empty)
            {
                screenHint.GetComponent<TextMeshProUGUI>().text = quest;
            }
            
            if (showScreenHint == true)
            {
                screenHint.SetActive(true);
            }
        }
    }

    IEnumerator TypeLine()
    {
        int count = 0;
        foreach (char c in dialogueComponents[index].lines.ToCharArray())
        {
            if (count == 0)
            {
                GameObject.Find("CharacterImage").GetComponent<RawImage>().texture = dialogueComponents[index].characterImg;
                if (dialogueComponents[index].charName == string.Empty)
                {
                    GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>().text = "Unity-chan";
                } else
                {
                    GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>().text = dialogueComponents[index].charName;
                }
                count++;
            }
            dialogueComponents[index].textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
