using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public UpgradePanel upgradePanel;
    public GameObject statusText;
    public GameObject statusBox;
    public GameObject autoCoin;
    public GameObject fakeButton;
    public GameObject fakeText;
    public GameObject realButtton;
    public GameObject realText;
    public GameObject droidStats;
    public double currentCoins;
    public static double upgradeValue = 4;
    public static bool turnOffButton = false;
    public static double numOfDroids;
    public static double coinsPerSec;


    public void ClickButton()
    {

        StartCoroutine(playAnim());

        if (upgradePanel != null)
        {
            bool isActive = upgradePanel.panel.activeSelf;
            upgradePanel.panel.SetActive(!isActive);
        }
    }

    private IEnumerator playAnim()
    {
        

        if (currentCoins <= 0 || currentCoins < upgradeValue)
        {
            //This handles Buttons
            fakeButton.SetActive(false);
            realButtton.SetActive(true);

            //This Handles Animation
            statusBox.SetActive(true);
            statusText.GetComponent<Text>().text = "Not enough coins to purchase upgrade.";
            yield return new WaitForSeconds(0.25f);
            statusBox.GetComponent<Animation>().Play("StatusAnim");
            yield return new WaitForSeconds(0.25f);
            statusBox.SetActive(false);

        }
        else
        {
            //GlobalCoins.CoinCount -= 1;
            StartAutoCoin();
        }

        if (turnOffButton == true)
        {
            realButtton.SetActive(false);
            fakeButton.SetActive(true);
            turnOffButton = false;
        }
    }

    public void StartAutoCoin()
    {
        autoCoin.SetActive(true);
        //fillBar.start = true;

        GlobalCoins.CoinCount -= upgradeValue;
        upgradeValue *= 2;
        turnOffButton = true;
        coinsPerSec += 1;
        numOfDroids += 1;

    }

    private void Update()
    {
        //Tracks current coins
        currentCoins = GlobalCoins.CoinCount;

        droidStats.GetComponent<Text>().text = "Droids: " + numOfDroids + " @ " + coinsPerSec + " coins(s)";

        //Handles upgrade button text
        fakeText.GetComponent<Text>().text = "Buy upgrade - £" + upgradeValue;
        realText.GetComponent<Text>().text = "Buy upgrade - £" + upgradeValue;



    }
}
