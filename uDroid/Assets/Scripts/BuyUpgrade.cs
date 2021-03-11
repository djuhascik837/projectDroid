using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    #region Variables

    public SliderIncrease[] sliderIncrease;
    public Plots[] plots;
    public GameObject[] inactivePlots;
    public ParticleSystem[] coinParticles;
    public UpgradePanel upgradePanel;
    public OpenMenuAnim openMenuAnim;
    public OpenMenuAnim openErrorMsg;
    public AutoCoins autoCoins;
    public GameObject statusText;
    public GameObject autoCoinObj;
    public GameObject droidStats;
    public GameObject runScriptParticles;
    public GameObject coinParticlesObj;
    public SoundManager soundManager;

    public double currentCoins;


    public static float upgradeMultiplier = 1.75f;
    public static bool buyNewPlotClicked = false;
    public static bool autoCoinClicked = false;
    public static bool autoCoinIncreaseClicked = false;
    public static bool sliderMultiClicked = false;
    public static bool upgradePerClicked = false;
    public static bool upgradeClickPowerMul = false;
    public static bool droidSpeedClicked = false;

    //All upgrade values
    public float upgradePlotValue1 = 1;
    public float upgradePlotValue2 = 2;
    public float upgradePlotValue3 = 3;

    private bool unlockPlot1 = false;
    private bool unlockPlot2 = false;
    private bool unlockPlot3 = false;
    public bool unlockedPlot1 = false;
    public bool unlockedPlot2 = false;
    public bool unlockedPlot3 = false;

    public float autoCoinUpgradeValue = 1;
    public float autoCoinIncreaseValue = 1;
    public float droidSpeedUpgradeValue = 1;

    public double numOfDroids;
    public double coinsPerDroid = 1;


    //All private variables
    private bool UpgradeClick1 = false;
    private bool UpgradeClick2 = false;
    private bool UpgradeClick3 = false;
    private bool UpgradeClick4 = false;
    private bool isAvailable = false;


    #endregion


    #region Clicking Upgrades

    public void ClickUpgradeCoin()
    {
        if (currentCoins < Mathf.RoundToInt((float)autoCoinUpgradeValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();
        }
        else
        {
            isAvailable = true;
            autoCoinClicked = true;
            ToggleParticleOn(coinParticles[3]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();
        }
    }

    public void ClickIncreaseCoin()
    {
        if (currentCoins < Mathf.RoundToInt((float)autoCoinIncreaseValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();
        }
        else
        {
            isAvailable = true;
            autoCoinIncreaseClicked = true;
            ToggleParticleOn(coinParticles[4]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();
        }
    }

    public void ClickDroidSpeed()
    {
        if (currentCoins < Mathf.RoundToInt((float)droidSpeedUpgradeValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();
        }
        else
        {
            isAvailable = true;
            droidSpeedClicked = true;
            ToggleParticleOn(coinParticles[5]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();
        }
    }

    


    ////////////////////////////////////
    //The below code checks the 3 inactive pltos and which one has been clicked so that they may unlock
    public void ClickBuyNewPlot1()
    {
        if (currentCoins < upgradePlotValue1)
        {
            isAvailable = false;
            playAnim();
        }
        else
        {
            isAvailable = true;
            buyNewPlotClicked = true;
            unlockPlot1 = true;
            ToggleParticleOn(coinParticles[0]);
            playAnim();
            soundManager.purchaseSound.Play();
            unlockPlot1 = false;
            unlockedPlot1 = true;
        }

    }

    public void ClickBuyNewPlot2()
    {
        if (currentCoins < upgradePlotValue2)
        {
            isAvailable = false;
            playAnim();

            print(upgradePlotValue2);
        }
        else
        {
            isAvailable = true;
            buyNewPlotClicked = true;
            unlockPlot2 = true;
            ToggleParticleOn(coinParticles[1]);
            playAnim();
            soundManager.purchaseSound.Play();
            unlockPlot2 = false;
            unlockedPlot2 = true;
        }

    }

    public void ClickBuyNewPlot3()
    {
        if (currentCoins < upgradePlotValue3)
        {
            isAvailable = false;
            playAnim();
        }
        else
        {
            isAvailable = true;
            buyNewPlotClicked = true;
            unlockPlot3 = true;
            ToggleParticleOn(coinParticles[2]);
            playAnim();
            soundManager.purchaseSound.Play();
            unlockPlot3 = false;
            unlockedPlot3 = true;
        }

    }

    public void checkSliderMultiplier(Plots plot)
    {
        if (currentCoins < Mathf.RoundToInt((float)plot.sliderMulUpgradeValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();

        }
        else
        {
            isAvailable = true;
            sliderMultiClicked = true;
            ToggleParticleOn(coinParticles[6]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();

        }
    }

    public void checkAmountPerClick(Plots plot)
    {
        if (currentCoins < Mathf.RoundToInt((float)plot.perClickUpgradeValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();
        }
        else
        {
            isAvailable = true;
            upgradePerClicked = true;
            ToggleParticleOn(coinParticles[7]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();
        }
    }

    public void checkClickPower(Plots plot)
    {
        if (currentCoins < Mathf.RoundToInt((float)plot.clickPowerUpgradeValue))
        {
            isAvailable = false;
            playAnim();
            openMenuAnim.pressButton();
        }
        else
        {
            isAvailable = true;
            upgradeClickPowerMul = true;
            ToggleParticleOn(coinParticles[8]);
            playAnim();
            openMenuAnim.pressButton();
            soundManager.purchaseSound.Play();
        }
    }

    #endregion


    #region Logic for Upgrades



    //This method updates the price of each upgrade separetly
    public void updatePrice()
    {

        if (autoCoinClicked == true)
        {
            GlobalCoins.CoinCount -= autoCoinUpgradeValue;
            autoCoinUpgradeValue *= upgradeMultiplier;
        }
        
        else if (autoCoinIncreaseClicked == true)
        {
            GlobalCoins.CoinCount -= autoCoinIncreaseValue;
            autoCoinIncreaseValue *= upgradeMultiplier;
        }
        else if (droidSpeedClicked == true)
        {
            GlobalCoins.CoinCount -= droidSpeedUpgradeValue;
            droidSpeedUpgradeValue *= upgradeMultiplier;
        }

        if (unlockPlot1 == true)
        {
            currentCoins -= upgradePlotValue1;
            print(4);
        }

        if (unlockPlot2 == true)
        {
            currentCoins -= upgradePlotValue2;
            print(5);
        }

        if (unlockPlot3 == true)
        {
            currentCoins -= upgradePlotValue3;
            print(6);
        }

        if (UpgradeClick1 == true)
        {
            updateIndividualPrice(plots[0]);
        }
        else if (UpgradeClick2 == true)
        {
            updateIndividualPrice(plots[1]);
        }
        else if (UpgradeClick3 == true)
        {
            updateIndividualPrice(plots[2]);
        }
        else if (UpgradeClick4 == true)
        {
            updateIndividualPrice(plots[3]);
        }



    }

    private void updateIndividualPrice(Plots plot)
    {
        if (sliderMultiClicked == true)
        {
            currentCoins -= plot.sliderMulUpgradeValue;
            plot.sliderMulUpgradeValue *= upgradeMultiplier;


        }
        
        else if (upgradePerClicked == true)
        {
            currentCoins -= plot.perClickUpgradeValue;
            plot.perClickUpgradeValue *= upgradeMultiplier;
            print(plot.perClickUpgradeValue);

        }
        
        else if (upgradeClickPowerMul == true)
        {
            currentCoins -= plot.clickPowerUpgradeValue;
            plot.clickPowerUpgradeValue *= upgradeMultiplier;
            print(plot.clickPowerUpgradeValue);

        }
    }

    //Code for purchasing new plots, This sets the plots false revealing the usable plots behind.
    public void buyNewPlot()
    {
        if (unlockPlot1 == true)
        {
            updatePrice();
            inactivePlots[0].SetActive(false);
        }

        if (unlockPlot2 == true)
        {
            updatePrice();
            inactivePlots[1].SetActive(false);
        }

        if (unlockPlot3 == true)
        {
            updatePrice();
            inactivePlots[2].SetActive(false);
        }

    }


    public void ClickSliderMultiplier()
    {
        if (UpgradeClick1 == true)
        {
            checkSliderMultiplier(plots[0]);
        }

        else if (UpgradeClick2 == true)
        {
            checkSliderMultiplier(plots[1]);
        }

        else if (UpgradeClick3 == true)
        {
            checkSliderMultiplier(plots[2]);
        }

        else if (UpgradeClick4 == true)
        {
            checkSliderMultiplier(plots[3]);
        }

        //print(currentCoins);
        //print(Mathf.RoundToInt((float)sliderMulUpgradeValue));
        //print(sliderNum);
    }

    public void ClickAmountPerClick()
    {
        if (UpgradeClick1 == true) 
        {
            checkAmountPerClick(plots[0]);
        }

        else if (UpgradeClick2 == true)
        {
            checkAmountPerClick(plots[1]);
        }

        else if (UpgradeClick3 == true)
        {
            checkAmountPerClick(plots[2]);
        }

        else if (UpgradeClick4 == true)
        {
            checkAmountPerClick(plots[3]);
        }
    }


    public void ClickPowerMultiplier()
    {
        if (UpgradeClick1 == true)
        {
            checkClickPower(plots[0]);
        }

        else if (UpgradeClick2 == true)
        {
            checkClickPower(plots[1]);
        }

        else if (UpgradeClick3 == true)
        {
            checkClickPower(plots[2]);
        }

        else if (UpgradeClick4 == true)
        {
            checkClickPower(plots[3]);
        }

    }

    //This automatically generates coins and adds them
    public void StartAutoCoin()
    {
        updatePrice();
        autoCoinObj.SetActive(true);
        //fillBar.start = true;
        numOfDroids += 1;
    }

    public void autoCoinIncrease()
    {
        updatePrice();
        coinsPerDroid *= upgradeMultiplier;
        coinsPerDroid = Mathf.RoundToInt((float)coinsPerDroid);
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

    #endregion


    #region Set and Toggle Methods

    //This checks which upgrade button has been clicked per plot
    public void setSliderUpgradeBoolTrue(Slider slider)
    {
        runScriptParticles.SetActive(false);
        //coinParticlesObj.SetActive(false);
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

        buyNewPlotClicked = false;

        runScriptParticles.SetActive(true);
        coinParticlesObj.SetActive(true);

        for(int i = 0; i < coinParticles.Length; i++)
        {
            ToggleParticleOff(coinParticles[i]);
        }

        
    }


    public void ToggleParticleOn(ParticleSystem particleSystem)
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }

    }

    public void ToggleParticleOff(ParticleSystem particleSystem)
    {
        if (particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }

    private void setPlotsInfo()
    {
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

    private void displayUpgradeValues()
    {
        //Handles upgrade button text
        upgradePanel.upgradeCoinText.GetComponent<Text>().text = "Buy Droids: " + Mathf.Round((float)autoCoinUpgradeValue);
        upgradePanel.upgradeCoinIncreaseText.GetComponent<Text>().text = "Droid Manufacturing: " + Mathf.Round((float)autoCoinIncreaseValue);
        upgradePanel.upgradeCLickCoinGenerationText.GetComponent<Text>().text = "Speed up the droids: " + Mathf.Round((float)droidSpeedUpgradeValue);

        if (UpgradeClick1 == true)
        {

            displayUpgradeIndividualValyes(plots[0]);
        }

        if (UpgradeClick2 == true)
        {

            displayUpgradeIndividualValyes(plots[1]);
        }

        if (UpgradeClick3 == true)
        {

            displayUpgradeIndividualValyes(plots[2]);
        }

        if (UpgradeClick4 == true)
        {

            displayUpgradeIndividualValyes(plots[3]);
        }


    }

    private void displayUpgradeIndividualValyes(Plots plot)
    {
        upgradePanel.upgradeSliderText.GetComponent<Text>().text = "Increase Slider: " + Mathf.Round((float)plot.sliderMulUpgradeValue);
        upgradePanel.upgradeClickText.GetComponent<Text>().text = "Coins per Click: " + Mathf.Round((float)plot.perClickUpgradeValue);
        upgradePanel.upgradeCLickMultiplierText.GetComponent<Text>().text = "Click Power Upgrade: " + Mathf.Round((float)plot.clickPowerUpgradeValue);
    }

    #endregion


    #region Animation Handlers

    //This method manages the animations that play when the UpgradePanel has been displayed and
    //makes sure the menu closes when an upgrade has been purchased.
    private void playAnim()
    {

        if (currentCoins <= 0 || isAvailable == false)
        {
            playErrorMsg("Not enough coins to purchase upgrade.");
            setUpgradeBoolFalse();
            isAvailable = false;
        }
        else if (buyNewPlotClicked == true)
        {
            buyNewPlot();
            setUpgradeBoolFalse();
            isAvailable = false;
            soundManager.unlockPlotSound.Play();


        }
        else if (autoCoinClicked == true)
        {
            StartAutoCoin();
            setUpgradeBoolFalse();
            autoCoinClicked = false;
            isAvailable = false;

        }
        else if (autoCoinIncreaseClicked == true)
        {
            autoCoinIncrease();
            setUpgradeBoolFalse();
            autoCoinIncreaseClicked = false;
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
    public void playErrorMsg(string errorMsg)
    {
        //This Handles Animation of not enough coins message

        statusText.GetComponent<Text>().text = errorMsg;
        openErrorMsg.GetComponent<Animation>().Play("StatusAnim");
        setUpgradeBoolFalse();
    }

    #endregion


    #region Update

    //Update Method which keeps track of the current coins and also updates the texts on screen.
    //There may be a way to do this more efficiently however this current implementation works.
    private void Update()
    {
        //Tracks current coins
        //currentCoins = Mathf.Round((float)GlobalCoins.CoinCount);
        GlobalCoins.CoinCount = currentCoins;

        if(numOfDroids == 0)
        {
            droidStats.GetComponent<Text>().text = "Droids help to generate coins";
        } else
        {
            droidStats.GetComponent<Text>().text = numOfDroids + " Droids: " + coinsPerDroid + " per " + autoCoins.seconds.ToString("F2") + "(s) ";
        }


        displayUpgradeValues();
        setPlotsInfo();

    }


    #endregion

    #region Methods no longer used
    //Method no longer in use, keeping for testing.
    //public void ClosePanel()
    //{
    //    if (upgradePanel != null)
    //    {
    //        bool isActive = upgradePanel.panel.activeSelf;
    //        upgradePanel.panel.SetActive(!isActive);

    //    }
    //}


    //public void setPlotUpgradeBoolTrue(GameObject inactivePlots)
    //{
    //    if (inactivePlots.name == "InactiveButton1")
    //    {
    //        unlockPlot1 = true;

    //    }

    //    if (inactivePlots.name == "InactiveButton2")
    //    {
    //        unlockPlot2 = true;

    //    }

    //    if (inactivePlots.name == "InactiveButton3")
    //    {
    //        unlockPlot3 = true;

    //    }
    //}

    #endregion

}
