using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static InputField input;
    public static string textFieldCompare;

    public OpenMenuAnim openErrorMsg;
    public GameObject statusText;

    public void GetInput(string userInput)
    {
        if(input != null)
        {
            string lowerCase = userInput.ToString().ToLower();
            print("Enter " + textFieldCompare + " to succeed");

            if (!string.IsNullOrWhiteSpace(textFieldCompare))
            {
                if (lowerCase.Equals(textFieldCompare.ToLower()))
                {
                    print(lowerCase + ", " + textFieldCompare.ToLower() + ": Success : added Coins");
                    GlobalCoins.CoinCount += 50;

                    PlayMsg("Test");
                }
            }
            else
            {
                Debug.LogWarning("textField Compare is null");
            }

            //string text = textFieldCompare.text;

            //text = text.Remove(0,1);
            //text = text.Remove(text.Length - 1, 1);

            //if (text != null)
            //{
            //    print(lowerCase);
            //    print(text.ToLower());
            //    if (text.ToLower() == lowerCase) Debug.Log(lowerCase + ", " + text.ToLower());
            //}

            input.text = "";
        }
    }

    private void PlayMsg(string Msg)
    {
        //This Handles Animation of not enough coins message

        statusText.GetComponent<Text>().text = Msg;
        openErrorMsg.GetComponent<Animation>().Play("StatusAnim");
    }
}
