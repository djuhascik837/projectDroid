﻿using UnityEngine;
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
    public static bool commentsCheck = false;

    public static int numOfInputs;
    public static bool successful;

    public static bool submit;

    public ParticleSystem starParticles;
    public SoundManager soundManager;
    public BuyUpgrade buyUpgrade;
    public GlobalCoins globalCoins;

    private void CheckInput(InputField methodInput, string compareField)
    {
        string lowerCase = methodInput.text.ToString().ToLower();

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
    }
    private void CheckMethodsInput(InputField methodInput, string compareField)
    {
        if (methodInput != null)
        {
            string lowerCase = methodInput.text.ToString().ToLower();

            if (lowerCase.Substring(lowerCase.Length - 2, 2).Equals(compareField))
            {
                inputSuccess = false;
                methodsCheck = false;
            }
        }
    }

    private void CheckCommentsInput(InputField commentsInput)
    {
        if (commentsInput != null)
        {
            string subUserInput = commentsInput.text.Substring(0, 2);

            print("1." + subUserInput.Equals("//"));

            if (subUserInput.Equals("//"))
            {
                inputSuccess = false;
                commentsCheck = false;
            }
        }
    }

    private void SuccessTrigger(int coinsToGive)
    {
        print(inputSuccess + ", " + inputSuccess2 + ", " + inputSuccess3 + ", " + inputSuccess4 + ", " + submit);
        //print("inputSuccesses: " + (inputSuccess || inputSuccess2 || inputSuccess3 || inputSuccess4) + ", submit: " + submit);
        if((!inputSuccess && !inputSuccess2 && !inputSuccess3 && !inputSuccess4) && submit)
        {
            GlobalCoins.CoinCount += coinsToGive;
            ToggleParticleOn(starParticles, true);

            SuccessMessage("Correct! Well done, here's " + coinsToGive + " coins.");
            soundManager.successSound.Play();
            OpenIDE script = GameObject.Find("IDE - Panel").GetComponent<OpenIDE>();
            script.StartNextTutorial();
        }
        else if ((inputSuccess || inputSuccess2 || inputSuccess3 || inputSuccess4) && submit)
        {
            soundManager.wrongAnswerSound.Play();
            switch (numOfInputs)
            {
                case 1:
                    if(!string.IsNullOrEmpty(input.text)) FailureMessage("Ooops sorry wrong answer, please try again!");
                    break;
                case 2: if (!(string.IsNullOrEmpty(input.text) && string.IsNullOrEmpty(input2.text)))
                    {
                        FailureMessage("Ooops sorry wrong answer, please try again!");
                    }
                    break;
                case 3:
                    if (!(string.IsNullOrEmpty(input.text) || string.IsNullOrEmpty(input2.text) || string.IsNullOrEmpty(input3.text)))
                    {
                        FailureMessage("Ooops sorry wrong answer, please try again!");
                    }
                    break;
                case 4:
                    if (!(string.IsNullOrEmpty(input.text) || string.IsNullOrEmpty(input2.text) || string.IsNullOrEmpty(input4.text) || string.IsNullOrEmpty(input4.text)))
                    {
                        FailureMessage("Ooops sorry wrong answer, please try again!");
                    }
                    break;
            }
        }
        ToggleParticleOn(starParticles, false);
    }

    public void GetInput()
    {
        print("Get Input Started");
        if (methodsCheck)
        {
            CheckMethodsInput(input, "()");
        }
        else if(commentsCheck)
        {
            CheckCommentsInput(input);
        }
        else
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

            int coinsToGive = 50;

            SuccessTrigger(coinsToGive);
        }
    }

    public GameObject successFailureMsgPanel;

    private void SuccessMessage(string message)
    {
        Text msgText = successFailureMsgPanel.GetComponentInChildren<Text>();
        msgText.text = message;

        Image msgImage = successFailureMsgPanel.GetComponent<Image>();
        // rgb colors
        byte redColor = 6;
        byte greenColor = 114;
        byte blueColor = 83;
        byte alpha = 208;

        Color32 rgb = new Color32(redColor, greenColor, blueColor, alpha);

        msgImage.color = rgb;
        print(msgImage.color.r);

        if (successFailureMsgPanel)
        {
            Animator anim = successFailureMsgPanel.GetComponent<Animator>();
            if (anim)
            {
                anim.Play("Message Open");

            }
        }
    }

    private void FailureMessage(string message)
    {
        Text msgText = successFailureMsgPanel.GetComponentInChildren<Text>();
        msgText.text = message;

        Image msgImage = successFailureMsgPanel.GetComponent<Image>();
        // rgb colors
        byte redColor = 217;
        byte greenColor = 70;
        byte blueColor = 70;
        byte alpha = 208;

        Color32 rgb = new Color32(redColor, greenColor, blueColor, alpha);

        msgImage.color = rgb;

        if (successFailureMsgPanel)
        {
            Animator anim = successFailureMsgPanel.GetComponent<Animator>();
            if (anim)
            {
                anim.Play("Message Open");

            }
        }
    }

    private void Start()
    {
        DeactivateRequiredComponents();
        ActivateRequiredComponents();
        soundManager.backgroundSound.Play();

        if (buyUpgrade.unlockedPlot1)
        {
            buyUpgrade.inactivePlots[0].SetActive(false);
        }

        if (buyUpgrade.unlockedPlot2)
        {
            buyUpgrade.inactivePlots[1].SetActive(false);
        }

        if (buyUpgrade.unlockedPlot3)
        {
            buyUpgrade.inactivePlots[2].SetActive(false);
        }
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

    public void ToggleParticleOn(ParticleSystem particleSystem, bool turnOn)
    {
        if(turnOn)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        } else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }


    #region Loading and Saving player data
    private void Awake()
    {
        LoadPlayerData();
    }



    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadData();

        //Updates the amount of current coins from the save file
        buyUpgrade.currentCoins = data.coins;
        GlobalCoins.CoinCount = buyUpgrade.currentCoins;

        //Updates all the different coin modifiers from the save file
        //buyUpgrade.autoCoinUpgradeValue = data.autoCoinUpgradeValue;
        //buyUpgrade.autoCoinIncreaseValue = data.autoCoinIncreaseValue;
        //buyUpgrade.perClickUpgradeValue = data.perClickUpgradeValue;
        //buyUpgrade.clickPowerUpgradeValue = data.clickPowerUpgradeValue;
        //buyUpgrade.droidSpeedUpgradeValue = data.droidSpeedUpgradeValue;
        //buyUpgrade.numOfDroids = data.numOfDroids;
        //buyUpgrade.coinsPerDroid = data.coinsPerDroid;

        //Updates whether or not the plots have been purchased or not
        buyUpgrade.unlockedPlot1 = data.unlockedPlot1;
        buyUpgrade.unlockedPlot2 = data.unlockedPlot2;
        buyUpgrade.unlockedPlot3 = data.unlockedPlot3;


    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveData(buyUpgrade);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSystem.SaveData(buyUpgrade);
        } else
        {
            LoadPlayerData();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.SaveData(buyUpgrade);
        } else
        {
            LoadPlayerData();
        }
    }

    #endregion
}
