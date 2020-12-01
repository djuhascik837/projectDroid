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
    public GameObject droidStats;
    public double currentCoins;
    public static double upgradeValue = 4;
    public static bool autoCoinClicked = false;
    public static double numOfDroids;
    public static double coinsPerSec;
    public double upgradeMultiplier = 1.5;


    public void ClickUpgradeCoin()
    {
        autoCoinClicked = true;
        StartCoroutine(playAnim());
        ClosePanel();
        
    }

    public void ClickSliderMultiplier()
    {
        StartCoroutine(playAnim());
        ClosePanel();
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

        }
        else if (autoCoinClicked == true)
        {
            StartAutoCoin();
        }        
    }

    public void StartAutoCoin()
    {
        autoCoin.SetActive(true);
        //fillBar.start = true;

        GlobalCoins.CoinCount -= upgradeValue;
        upgradeValue *= upgradeMultiplier;        
        coinsPerSec += 1;
        numOfDroids += 1;

    }

    private void Update()
    {
        //Tracks current coins
        currentCoins = GlobalCoins.CoinCount;

        droidStats.GetComponent<Text>().text = "Droids: " + numOfDroids + " @ " + coinsPerSec + " coins(s)";

        //Handles upgrade button text
        upgradePanel.upgradeCoinText.GetComponent<Text>().text = "Buy Auto Coins - £" + Mathf.Round((float)upgradeValue);



    }

    public void ClosePanel()
    {
        if (upgradePanel != null)
        {
            bool isActive = upgradePanel.panel.activeSelf;
            upgradePanel.panel.SetActive(!isActive);

        }
    }
}
