using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    ////////////////////////////////////
    // Varriables
    
    public UpgradePanel upgradePanel;
    public OpenMenuAnim openAnim;
    public SliderIncrease[] sliderIncrease;
    public AutoCoins autoCoins;
    public GlobalCoins globalCoins;
    public GameObject statusText;
    public GameObject statusBox;
    public GameObject autoCoinObj;
    public GameObject droidStats;

    public double currentCoins;
    public static bool autoCoinClicked = false;
    public static bool sliderMultiClicked = false;
    public static bool upgradePerClicked = false;
    public static bool upgradeClickPowerMul = false;
    public static bool droidSpeedClicked = false;
    public static double numOfDroids;
    public static double coinsPerDroid;

    //All upgrade values
    public static double autoCoinUpgradeValue = 4;
    public static double sliderMulUpgradeValue = 6;
    public static double perClickUpgradeValue = 8;
    public static double clickPowerUpgradeValue = 10;
    public static double droidSpeedUpgradeValue = 12;

    public double upgradeMultiplier = 1.25;
    public double amountPerClick = 1.0;
    public double clickPower = 1.25;

    //All private variables
    private bool UpgradeClick1 = false;
    private bool UpgradeClick2 = false;
    private bool UpgradeClick3 = false;
    private bool UpgradeClick4 = false;
    private bool isAvailable = false;

    ////////////////////////////////////


    ////////////////////////////////////
    // Upgrade Methods
    // Checks if upgrade button has been clicked

    public void ClickUpgradeCoin()
    {
        if (currentCoins < autoCoinUpgradeValue)
        {
            isAvailable = false;
            StartCoroutine(playAnim());
            openAnim.press();
        } 
        else
        {
            isAvailable = true;
            autoCoinClicked = true;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        
    }

    public void ClickSliderMultiplier()
    {
        if (currentCoins < sliderMulUpgradeValue)
        {
            isAvailable = false;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        else
        {
            isAvailable = true;
            sliderMultiClicked = true;
            StartCoroutine(playAnim());
            openAnim.press();
        }
    }

    public void ClickAmountPerClick()
    {
        if (currentCoins < perClickUpgradeValue)
        {
            isAvailable = false;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        else
        {
            isAvailable = true;
            upgradePerClicked = true;
            StartCoroutine(playAnim());
            openAnim.press();
        }
    }

    public void ClickPowerMultiplier()
    {
        if (currentCoins < clickPowerUpgradeValue)
        {
            isAvailable = false;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        else
        {
            isAvailable = true;
            upgradeClickPowerMul = true;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        
    }

    public void ClickDroidSpeed()
    {
        if (currentCoins < droidSpeedUpgradeValue)
        {
            isAvailable = false;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        else
        {
            isAvailable = true;
            droidSpeedClicked = true;
            StartCoroutine(playAnim());
            openAnim.press();
        }
        
    }

    //////////////////////////////////////
    //The actual logic behind the upgrades

    public void updatePrice()
    {

        if (autoCoinClicked == true)
        {
            GlobalCoins.CoinCount -= autoCoinUpgradeValue;
            autoCoinUpgradeValue *= upgradeMultiplier;
        } 
        else if (sliderMultiClicked == true)
        {
            GlobalCoins.CoinCount -= sliderMulUpgradeValue;
            sliderMulUpgradeValue *= upgradeMultiplier;
        } 
        else if (upgradePerClicked == true)
        {
            GlobalCoins.CoinCount -= perClickUpgradeValue;
            perClickUpgradeValue *= upgradeMultiplier;
        } 
        else if (upgradeClickPowerMul == true)
        {
            GlobalCoins.CoinCount -= clickPowerUpgradeValue;
            clickPowerUpgradeValue *= upgradeMultiplier;
        } 
        else if (droidSpeedClicked == true)
        {
            GlobalCoins.CoinCount -= droidSpeedUpgradeValue;
            droidSpeedUpgradeValue *= upgradeMultiplier;
        }
        //GlobalCoins.CoinCount -= upgradeValue;
        //upgradeValue *= upgradeMultiplier;
    }

    public void StartAutoCoin()
    {
        //This automatically generates coins and adds them
        autoCoinObj.SetActive(true);
        //fillBar.start = true;
        //TODO: this is where I can set different upgradevalues for each upgrade
        updatePrice();
        coinsPerDroid += 1;
        numOfDroids += 1;
        upgradePanel.upgradeCoin.SetActive(false);

    }

    public void SliderMultiplier(SliderIncrease sliderIncrease)
    {
        //This increases the time it takes for the slider to finish
        //TODO: this is where I can set different upgradevalues for each upgrade
        updatePrice();
        sliderIncrease.multiplier *= 1.7f;
        upgradePanel.upgradeSlider.SetActive(false);
    }

    public void upgradePerClick()
    {
        //This increases the amount of coins generated per click
        //TODO: this is where I can set different upgradevalues for each upgrade
        updatePrice();
        amountPerClick *= clickPower;
        print("Amount per: " + amountPerClick);

    }

    public void upgradeClickPowerMultiplier()
    {
        updatePrice();
        clickPower *= 1.15;
        print("Click Power: " + clickPower);
    }

    public void droidSpeed(AutoCoins autoCoins)
    {
        updatePrice();
        autoCoins.seconds /= 1.05f;
        
    }

    public void setUpgradeBoolTrue(Slider slider)
    {
        if (slider.name == "Slider 1 - Slider")
        {
            UpgradeClick1 = true;
            //print("1" + UpgradeClick1);
        }
        else if (slider.name == "Slider 2 - Slider")
        {
            UpgradeClick2 = true;
            //print("2" + UpgradeClick2);
        }
        else if (slider.name == "Slider 3 - Slider")
        {
            UpgradeClick3 = true;
            //print("3" + UpgradeClick3);
        }
        else if (slider.name == "Slider 4 - Slider")
        {
            UpgradeClick4 = true;
            //print("4" + UpgradeClick4);
        }

    }

    //Sets the upgrade buttons back to false, this is used for tracking which button has been clicked.
    //Used as an implementation for having upgrades seperate to each plot.
    public void setUpgradeBoolFalse()
    {
        UpgradeClick1 = false;
        UpgradeClick2 = false;
        UpgradeClick3 = false;
        UpgradeClick4 = false;
        //print("Upgrades set to false.");
    }
    //This drives the main logic behind purchasing upgrades
    
    ////////////////////////////////////
    
    private IEnumerator playAnim()
    {

        if (currentCoins <= 0 || isAvailable == false)
        {
            //This Handles Animation of not enough message
            statusBox.SetActive(true);
            statusText.GetComponent<Text>().text = "Not enough coins to purchase upgrade.";
            yield return new WaitForSeconds(0.25f);
            statusBox.GetComponent<Animation>().Play("StatusAnim");
            yield return new WaitForSeconds(0.25f);
            statusBox.SetActive(false);
            setUpgradeBoolFalse();
        }
        else if (autoCoinClicked == true)
        {
            StartAutoCoin();
            setUpgradeBoolFalse();
        }
        else if (sliderMultiClicked == true)
        {
            if (UpgradeClick1 == true)
            {
                SliderMultiplier(sliderIncrease[0]);
                UpgradeClick1 = false;
            }
            else if (UpgradeClick2 == true)
            {
                SliderMultiplier(sliderIncrease[1]);
                UpgradeClick2 = false;
            }
            else if (UpgradeClick3 == true)
            {
                SliderMultiplier(sliderIncrease[2]);
                UpgradeClick3 = false;
            }
            else if (UpgradeClick4 == true)
            {
                SliderMultiplier(sliderIncrease[3]);
                UpgradeClick4 = false;
            }

        }
        else if (upgradePerClicked == true)
        {
            upgradePerClick();
            setUpgradeBoolFalse();
            upgradePerClicked = false;
        }
        else if (upgradeClickPowerMul == true)
        {
            upgradeClickPowerMultiplier();
            setUpgradeBoolFalse();
            upgradeClickPowerMul = false;
        }
        else if (droidSpeedClicked == true)
        {
            droidSpeed(autoCoins);
            setUpgradeBoolFalse();
            droidSpeedClicked = false;
        }
    }

    private void Update()
    {
        //Tracks current coins
        currentCoins = GlobalCoins.CoinCount;

        droidStats.GetComponent<Text>().text = "Droids: " + numOfDroids + " per(" + autoCoins.seconds.ToString("F2") + "s) " + coinsPerDroid;

        //Handles upgrade button text 
        upgradePanel.upgradeCoinText.GetComponent<Text>().text = "Buy Auto Coins: " + Mathf.Round((float)autoCoinUpgradeValue);
        upgradePanel.upgradeSliderText.GetComponent<Text>().text = "Increase Slider: " + Mathf.Round((float)sliderMulUpgradeValue);
        upgradePanel.upgradeClickText.GetComponent<Text>().text = "Running script upgrade: " + Mathf.Round((float)perClickUpgradeValue);
        upgradePanel.upgradeCLickMultiplierText.GetComponent<Text>().text = "Upgrade Script Multiplier: " + Mathf.Round((float)clickPowerUpgradeValue);
        upgradePanel.upgradeCLickCoinGenerationText.GetComponent<Text>().text = "Speed up the droids: " + Mathf.Round((float)droidSpeedUpgradeValue);

        //print("SLIDER: " + sliderIncrease.multiplier);

    }

    //Method no longer in use, keeping for testing.
    //public void ClosePanel()
    //{
    //    if (upgradePanel != null)
    //    {
    //        bool isActive = upgradePanel.panel.activeSelf;
    //        upgradePanel.panel.SetActive(!isActive);

    //    }
    //}

}
