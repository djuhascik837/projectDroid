using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public double coins;
    public float autoCoinUpgradeValue;
    public float autoCoinIncreaseValue;
    public float sliderMulUpgradeValue;
    public float perClickUpgradeValue;
    public float clickPowerUpgradeValue;
    public float droidSpeedUpgradeValue;
    public double numOfDroids;
    public double coinsPerDroid;

    public bool unlockedPlot1;
    public bool unlockedPlot2;
    public bool unlockedPlot3;

    public PlayerData(BuyUpgrade buyUpgrade)
    {
        coins = GlobalCoins.CoinCount;

        //autoCoinUpgradeValue = buyUpgrade.autoCoinUpgradeValue;
        //autoCoinIncreaseValue = buyUpgrade.autoCoinIncreaseValue;
        //sliderMulUpgradeValue = buyUpgrade.sliderMulUpgradeValue;
        //perClickUpgradeValue = buyUpgrade.perClickUpgradeValue;
        //clickPowerUpgradeValue = buyUpgrade.clickPowerUpgradeValue;
        //droidSpeedUpgradeValue = buyUpgrade.droidSpeedUpgradeValue;
        //numOfDroids = buyUpgrade.numOfDroids;
        //coinsPerDroid = buyUpgrade.coinsPerDroid;

        unlockedPlot1 = buyUpgrade.unlockedPlot1;
        unlockedPlot2 = buyUpgrade.unlockedPlot2;
        unlockedPlot3 = buyUpgrade.unlockedPlot3;



    }



}
