using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static InputField input;
    public static InputField input2;
    public static InputField input3;
    public static InputField input4;
    public static string textFieldCompare;
    public static string textFieldCompare2;
    public static string textFieldCompare3;
    public static string textFieldCompare4;

    public static bool methodsCheck = false;

    public OpenMenuAnim openErrorMsg;
    public GameObject statusText;

    private void CheckInput(InputField input, string compareField, int coinsToGive)
    {
        string lowerCase = input.text.ToString().ToLower();
        print("Enter " + textFieldCompare + " to succeed");

        if (!string.IsNullOrWhiteSpace(compareField))
        {
            if (lowerCase.Equals(compareField.ToLower()))
            {
                print(lowerCase + ", " + compareField.ToLower() + ": Success : added Coins");
                GlobalCoins.CoinCount += coinsToGive;

                PlayMsg("Test");
            }
        }
        else
        {
            Debug.LogWarning("textField Compare is null");
        }

        input.text = "";
    }

    public void GetInput()
    {
        if (!methodsCheck)
        {
            if (input != null)
            {
                CheckInput(input, textFieldCompare, 50);
            }
            if (input2 != null)
            {
                CheckInput(input2, textFieldCompare2, 50);
            }
            if (input3 != null)
            {
                CheckInput(input3, textFieldCompare3, 50);
            }
            if (input4 != null)
            {
                CheckInput(input4, textFieldCompare4, 50);
            }
        }
        else
        {
            if (input != null)
            {
                string lowerCase = input.text.ToString().ToLower();
                //print("Enter " + textFieldCompare + " to succeed");

                string testCase = "()";

                if (lowerCase.Substring(lowerCase.Length - 1, 2).Equals(testCase))
                {
                    print(lowerCase + ", " + textFieldCompare.ToLower() + ": Success : added Coins");
                    GlobalCoins.CoinCount += 50;
                }
                else
                {
                    Debug.LogWarning("textField Compare is null");
                }

                input.text = "";
            }
        }
    }

    private void PlayMsg(string Msg)
    {
        //This Handles Animation of not enough coins message

        statusText.GetComponent<Text>().text = Msg;
        openErrorMsg.GetComponent<Animation>().Play("StatusAnim");
    }
}
