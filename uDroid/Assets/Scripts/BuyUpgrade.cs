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
    public Plots[] plots;
    public AutoCoins autoCoins;
    public GlobalCoins globalCoins;
    public GameObject statusText;
    public GameObject statusBox;
    public GameObject autoCoinObj;
    public GameObject droidStats;
    public GameObject particles;

    public double currentCoins;
    public static bool autoCoinClicked = false;
    public static bool sliderMultiClicked = false;
    public static bool upgradePerClicked = false;
    public static bool upgradeClickPowerMul = false;
    public static bool droidSpeedClicked = false;
    public static double numOfDroids;
    public static double coinsPerDroid;

    //All upgrade values
    private float autoCoinUpgradeValue = 1;
    private float sliderMulUpgradeValue = 1;
    private float perClickUpgradeValue = 1;
    private float clickPowerUpgradeValue = 1;
    private float droidSpeedUpgradeValue = 1;
    public float upgradeMultiplier;
    public int sliderNum;

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
        if (currentCoins < Mathf.RoundToInt((float)autoCoinUpgradeValue))
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
        if (currentCoins < Mathf.RoundToInt((float)sliderMulUpgradeValue))
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
        //print(currentCoins);
        //print(Mathf.RoundToInt((float)sliderMulUpgradeValue));
        //print(sliderNum);
    }

    public void ClickAmountPerClick()
    {
        if (currentCoins < Mathf.RoundToInt((float)perClickUpgradeValue))
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
        if (currentCoins < Mathf.RoundToInt((float)clickPowerUpgradeValue))
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
        if (currentCoins < Mathf.RoundToInt((float)droidSpeedUpgradeValue))
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

        //This method updates the price of each upgrade separetly
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
            sliderNum = Mathf.RoundToInt(sliderMulUpgradeValue);
            
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

    }

    //This automatically generates coins and adds them
    public void StartAutoCoin()
    {
        updatePrice();
        autoCoinObj.SetActive(true);
        //fillBar.start = true;
        coinsPerDroid += 1;
        numOfDroids += 1;
    }



    //This increases the time it takes for the slider to finish
    public void SliderMultiplier(SliderIncrease sliderIncrease)
    {
        updatePrice();
        sliderIncrease.multiplier *= 1.7f;
    }

    //This increases the amount of coins generated per click
    public void upgradePerClick(Plots plot)
    {
        updatePrice();
        plot.amountPerClick *= plot.clickPower;

    }

    //This increases the multiplier for coins generated per click
    public void upgradeClickPowerMultiplier(Plots plot)
    {
        updatePrice();
        plot.clickPower *= 1.15;
    }


    //This speeds up the generation of coins for the AutoCoins
    public void droidSpeed(AutoCoins autoCoins)
    {
        updatePrice();
        autoCoins.seconds /= 1.05f;

    }


    //This checks which upgrade button has been clicked per plot
    public void setUpgradeBoolTrue(Slider slider)
    {
        particles.SetActive(false);
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

        particles.SetActive(true);
    }
    //This drives the main logic behind purchasing upgrades
    
    ////////////////////////////////////
    

    //This method manages the animations that play when the UpgradePanel has been displayed and
    //makes sure the menu closes when an upgrade has been purchased.
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
            autoCoinClicked = false;
            isAvailable = false;

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

            setUpgradeBoolFalse();
            sliderMultiClicked = false;
            isAvailable = false;

        }
        else if (upgradePerClicked == true)
        {
            if (UpgradeClick1 == true)
            {
                upgradePerClick(plots[0]);
                UpgradeClick1 = false;
            } 
            else if (UpgradeClick2 == true)
            {
                upgradePerClick(plots[1]);
                UpgradeClick2 = false;
            }
            else if (UpgradeClick3 == true)
            {
                upgradePerClick(plots[2]);
                UpgradeClick3 = false;
            }
            else if (UpgradeClick4 == true)
            {
                upgradePerClick(plots[3]);
                UpgradeClick4 = false;
            }
            
            setUpgradeBoolFalse();
            upgradePerClicked = false;
            isAvailable = false;
        }
        else if (upgradeClickPowerMul == true)
        {
            if (UpgradeClick1 == true)
            {
                upgradeClickPowerMultiplier(plots[0]);
                UpgradeClick1 = false;
            }
            else if (UpgradeClick2 == true)
            {
                upgradeClickPowerMultiplier(plots[1]);
                UpgradeClick2 = false;
            }
            else if (UpgradeClick3 == true)
            {
                upgradeClickPowerMultiplier(plots[2]);
                UpgradeClick3 = false;
            }
            else if (UpgradeClick4 == true)
            {
                upgradeClickPowerMultiplier(plots[3]);
                UpgradeClick4 = false;
            }

            setUpgradeBoolFalse();
            upgradeClickPowerMul = false;
            isAvailable = false;
        }
        else if (droidSpeedClicked == true)
        {
            droidSpeed(autoCoins);
            setUpgradeBoolFalse();
            droidSpeedClicked = false;
            isAvailable = false;
        }
    }

    //Update Method which keeps track of the current coins and also updates the texts on screen.
    //There may be a way to do this more efficiently however this current implementation works.
    private void Update()
    {
        //Tracks current coins
        currentCoins = Mathf.Round((float)GlobalCoins.CoinCount);


        droidStats.GetComponent<Text>().text = "Droids: " + numOfDroids + " per(" + autoCoins.seconds.ToString("F2") + "s) " + coinsPerDroid;

        //Handles upgrade button text 
        upgradePanel.upgradeCoinText.GetComponent<Text>().text = "Buy Auto Coins: " + Mathf.Round((float)autoCoinUpgradeValue);
        upgradePanel.upgradeSliderText.GetComponent<Text>().text = "Increase Slider: " + Mathf.Round((float)sliderMulUpgradeValue);
        upgradePanel.upgradeClickText.GetComponent<Text>().text = "Coins per Click upgrade: " + Mathf.Round((float)perClickUpgradeValue);
        upgradePanel.upgradeCLickMultiplierText.GetComponent<Text>().text = "Click Power Upgrade: " + Mathf.Round((float)clickPowerUpgradeValue);
        upgradePanel.upgradeCLickCoinGenerationText.GetComponent<Text>().text = "Speed up the droids: " + Mathf.Round((float)droidSpeedUpgradeValue);

        float sliderIn0 = sliderIncrease[0].multiplier * 1000;
        float sliderIn1 = sliderIncrease[1].multiplier * 1000;
        float sliderIn2 = sliderIncrease[2].multiplier * 1000;
        float sliderIn3 = sliderIncrease[3].multiplier * 1000;


        //Updates the Information box below the run script buttons;
        plots[0].transform.Find("InfoText1").GetComponent<Text>().text = "Current Slider Speed: " + sliderIn0.ToString("F2") + "x"
            + "\nCoins per Click: " + plots[0].amountPerClick.ToString("F2") + "x" + "\nClick Power Upgrade: " + plots[0].clickPower.ToString("F2") + "x";

        plots[1].transform.Find("InfoText2").GetComponent<Text>().text = "Current Slider Speed: " + sliderIn1.ToString("F2") + "x"
            + "\nCoins per Click: " + plots[1].amountPerClick.ToString("F2") + "x" + "\nClick Power Upgrade: " + plots[1].clickPower.ToString("F2") + "x";

        plots[2].transform.Find("InfoText3").GetComponent<Text>().text = "Current Slider Speed: " + sliderIn2.ToString("F2") + "x"
            + "\nCoins per Click: " + plots[2].amountPerClick.ToString("F2") + "x" + "\nClick Power Upgrade: " + plots[2].clickPower.ToString("F2") + "x";

        plots[3].transform.Find("InfoText4").GetComponent<Text>().text = "Current Slider Speed: " + sliderIn3.ToString("F2") + "x"
            + "\nCoins per Click: " + plots[3].amountPerClick.ToString("F2") + "x" + "\nClick Power Upgrade: " + plots[3].clickPower.ToString("F2") + "x";


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
