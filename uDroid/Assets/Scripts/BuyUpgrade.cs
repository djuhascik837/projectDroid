using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public UpgradePanel upgradePanel;
    public OpenMenuAnim openAnim;
    public SliderIncrease[] sliderIncrease;
    public Button[] upgradeButton;
    public GameObject statusText;
    public GameObject statusBox;
    public GameObject autoCoin;
    public GameObject droidStats;
    public double currentCoins;
    public static double upgradeValue = 4;
    public static bool autoCoinClicked = false;
    public static bool sliderMultiClicked = false;
    public static double numOfDroids;
    public static double coinsPerSec;
    public double upgradeMultiplier = 1.25;

    private bool UpgradeClick1 = false;
    private bool UpgradeClick2 = false;
    private bool UpgradeClick3 = false;
    private bool UpgradeClick4 = false;


    public void ClickUpgradeCoin()
    {
        autoCoinClicked = true;
        StartCoroutine(playAnim());
        openAnim.press();
        
    }

    public void ClickSliderMultiplier()
    {
        sliderMultiClicked = true;
        StartCoroutine(playAnim());
        openAnim.press();
    }

    public void setUpgradeBoolTrue(Slider slider)
    {
        if(slider.name == "Slider 1 - Slider")
        {
            UpgradeClick1 = true;
            print("1" + UpgradeClick1);
        } else if (slider.name == "Slider 2 - Slider")
        {
            UpgradeClick2 = true;
            print("2" + UpgradeClick2);
        }
        else if (slider.name == "Slider 3 - Slider")
        {
            UpgradeClick3 = true;
            print("3" + UpgradeClick3);
        }
        else if (slider.name == "Slider 4 - Slider")
        {
            UpgradeClick4 = true;
            print("4" + UpgradeClick4);
        }

    }

    public void setUpgradeBoolFalse()
    {
        UpgradeClick1 = false;
        UpgradeClick2 = false;
        UpgradeClick3 = false;
        UpgradeClick4 = false;
        print("Upgrades set to false.");
    }

    private IEnumerator playAnim()
    {

        if (currentCoins <= 0 || currentCoins < upgradeValue)
        {
            //This Handles Animation
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
    }

    public void StartAutoCoin()
    {
        //This automatically generates coins and adds them
        autoCoin.SetActive(true);
        //fillBar.start = true;

        GlobalCoins.CoinCount -= upgradeValue;
        upgradeValue *= upgradeMultiplier;        
        coinsPerSec += 1;
        numOfDroids += 1;
        upgradePanel.upgradeCoin.SetActive(false);

    }

    public void SliderMultiplier(SliderIncrease sliderIncrease)
    {
        //This increases the time it takes for the slider to finish
        GlobalCoins.CoinCount -= upgradeValue;
        upgradeValue *= upgradeMultiplier;
        sliderIncrease.multiplier *= 1.7f;
        upgradePanel.upgradeSlider.SetActive(false);
    }

    private void Update()
    {
        //Tracks current coins
        currentCoins = GlobalCoins.CoinCount;

        droidStats.GetComponent<Text>().text = "Droids: " + numOfDroids + " @ " + coinsPerSec + " coins(s)";

        //Handles upgrade button text
        upgradePanel.upgradeCoinText.GetComponent<Text>().text = "Buy Auto Coins - £" + Mathf.Round((float)upgradeValue);
        upgradePanel.upgradeSliderText.GetComponent<Text>().text = "Increase Slider - £" + Mathf.Round((float)upgradeValue);
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
