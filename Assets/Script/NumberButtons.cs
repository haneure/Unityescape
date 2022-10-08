using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberButtons : MonoBehaviour
{
    public Button upButton, downButton;
    public TMP_Text digit;
    // Start is called before the first frame update
    void Start()
    {
        digit.text = (0).ToString();
        upButton.onClick.AddListener(increaseDigit);
        downButton.onClick.AddListener(decreaseDigit);
    }

    private void increaseDigit()
    {
        if(int.Parse(digit.text) >= 9)
        {
            digit.text = (0).ToString();
        }
        else
        {
            digit.text = (int.Parse(digit.text) + 1).ToString();
        }
    }

    private void decreaseDigit()
    {
        if(int.Parse(digit.text) <= 0)
        {
            digit.text = (9).ToString();
        }
        else
        {
            digit.text = (int.Parse(digit.text) - 1).ToString();
        }
    }
}
