using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class t_questUI : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text)
    {
        textComponent.text = text;
    }
}
