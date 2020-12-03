using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InputField input;
    public Text textFieldCompare;

    public void GetInput(string userInput)
    {
        if(input != null)
        {
            string lowerCase = userInput.ToString().ToLower();
            string text = textFieldCompare.text;

            text = text.Remove(0,1);
            text = text.Remove(text.Length - 1, 1);

            if (text != null)
            {
                if (text.ToLower() == lowerCase) Debug.Log(lowerCase + ", " + text.ToLower());
            }

            input.text = "";
        }
    }
}
