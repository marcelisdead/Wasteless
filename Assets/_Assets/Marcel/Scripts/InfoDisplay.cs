using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI topText;
    public TextMeshProUGUI botText;

    public void TopText(string newTxt)
    {
        topText.text = newTxt;
    }

    public void BotText(string newTxt)
    {
        botText.text = newTxt;
    }

    public void ClearInfo()
    {
        topText.text = "";
        botText.text = "";
    }
}
