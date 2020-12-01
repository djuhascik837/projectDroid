using System.Collections;
using System.Collections.Generic;
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

            Debug.Log(lowerCase + ", " + text.ToLower());

            if (text != null)
            {
                if (text.ToLower() == lowerCase) Debug.Log(lowerCase + ", " + text.ToLower());
            }

            input.text = "";
        }
    }
}
