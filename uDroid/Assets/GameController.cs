using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InputField input;

    public void GetInput(string userInput)
    {
        Debug.Log(userInput);
        if(input != null)
        {
            input.text = "";
        }
    }
}
