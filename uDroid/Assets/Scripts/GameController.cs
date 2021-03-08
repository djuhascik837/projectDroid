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
    public static bool inputSuccess;
    public static bool inputSuccess2;
    public static bool inputSuccess3;
    public static bool inputSuccess4;

    public static bool methodsCheck = false;

    private void CheckInput(InputField methodInput, string compareField)
    {
        string lowerCase = methodInput.text.ToString().ToLower();
        print("Enter " + compareField + " to succeed");

        if (!string.IsNullOrWhiteSpace(compareField))
        {
            if (lowerCase.Equals(compareField.ToLower()))
            {
                print(methodInput.name);
                if (methodInput == input)
                {
                    inputSuccess = false;
                }
                else if (methodInput == input2)
                {
                    inputSuccess2 = false;
                }
                else if (methodInput == input3)
                {
                    inputSuccess3 = false;
                }
                else if (methodInput == input4)
                {
                    inputSuccess4 = false;
                }
            }
        }
        else
        {
            Debug.LogWarning("textField Compare is null");
        }

        //methodInput.text = "";
    }
    private void CheckMethodsInput(InputField methodInput, string compareField)
    {
        if (methodInput != null)
        {
            string lowerCase = methodInput.text.ToString().ToLower();

            if (lowerCase.Substring(lowerCase.Length - 1, 2).Equals(compareField))
            {
                print(lowerCase + ", " + compareField.ToLower() + ": Success");

                inputSuccess = true;
            }

            //methodInput.text = "";
        }
    }

    private void SuccessTrigger(int coinsToGive)
    {
        print("Field 1: " + inputSuccess + ", Field 2: " + inputSuccess2 + ", Field 3: " + inputSuccess3 + ", Field 4: " + inputSuccess4);
        if(!inputSuccess && !inputSuccess2 && !inputSuccess3 && !inputSuccess4)
        {
            GlobalCoins.CoinCount += coinsToGive;
            print("Completed: " + coinsToGive + ", have been given");
            OpenIDE script = GameObject.Find("IDE - Panel").GetComponent<OpenIDE>();
            script.StartNextTutorial();
        }
        else
        {
            print("Failed: No coins have been added, please try again");
        }
    }

    public void GetInput()
    {
        print("Get Input Started");
        if (!methodsCheck)
        {
            if (input != null)
            {
                CheckInput(input, textFieldCompare);
            }
            if (input2 != null)
            {
                CheckInput(input2, textFieldCompare2);
            }
            if (input3 != null)
            {
                CheckInput(input3, textFieldCompare3);
            }
            if (input4 != null)
            {
                CheckInput(input4, textFieldCompare4);
            }

            SuccessTrigger(50);
        }
        else
        {
            CheckMethodsInput(input, "()");
        }
    }

    private void Start()
    {
        DeactivateRequiredComponents();
        ActivateRequiredComponents();
    }

    public GameObject[] deactivateList;
    public GameObject[] ActivateList;

    private void DeactivateRequiredComponents()
    {
        foreach (var item in deactivateList)
        {
            if(item.activeSelf == true)
            {
                item.SetActive(false);
            }
        }
    }
    private void ActivateRequiredComponents()
    {
        foreach (var item in ActivateList)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
            }
        }
    }
}
