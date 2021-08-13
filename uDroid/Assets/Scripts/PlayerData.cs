using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public double coins;
    public int globalCoinsToGive;
    public int tutLevel;
    public double autoCoinUpgradeValue;
    public double autoCoinIncreaseValue;
    public double droidSpeedUpgradeValue;
    public double numOfDroids;
    public double coinsPerDroid;
    public double autoCoinsSeconds;

    public bool unlockedPlot1;
    public bool unlockedPlot2;
    public bool unlockedPlot3;
    public bool autoCoinUnlocked;

    public double sliderMultiplier1;
    public double sliderMultiplier2;
    public double sliderMultiplier3;
    public double sliderMultiplier4;
    public double autoCoinsToGive;

    #region Plot Variables

    public double amountPerClick1;
    public double amountPerClick2;
    public double amountPerClick3;
    public double amountPerClick4;

    public double clickPower1;
    public double clickPower2;
    public double clickPower3;
    public double clickPower4;

    public double sliderMulUpgradeValue1;
    public double sliderMulUpgradeValue2;
    public double sliderMulUpgradeValue3;
    public double sliderMulUpgradeValue4;

    public double perClickUpgradeValue1;
    public double perClickUpgradeValue2;
    public double perClickUpgradeValue3;
    public double perClickUpgradeValue4;

    public double clickPowerUpgradeValue1;
    public double clickPowerUpgradeValue2;
    public double clickPowerUpgradeValue3;
    public double clickPowerUpgradeValue4;

    #endregion

    public PlayerData(BuyUpgrade buyUpgrade)
    {
        coins = GlobalCoins.CoinCount;
        globalCoinsToGive = GameController.globalCoinsToGive;
        tutLevel = OpenIDE.tutLevel;

        autoCoinsToGive = buyUpgrade.autoCoinsToGive;

        autoCoinUnlocked = buyUpgrade.autoCoinUnlocked;
        autoCoinsSeconds = buyUpgrade.autoCoins.seconds;


        autoCoinUpgradeValue = buyUpgrade.autoCoinUpgradeValue;
        autoCoinIncreaseValue = buyUpgrade.autoCoinIncreaseValue;
        droidSpeedUpgradeValue = buyUpgrade.droidSpeedUpgradeValue;
        numOfDroids = buyUpgrade.numOfDroids;
        coinsPerDroid = buyUpgrade.coinsPerDroid;

        unlockedPlot1 = buyUpgrade.unlockedPlot1;
        unlockedPlot2 = buyUpgrade.unlockedPlot2;
        unlockedPlot3 = buyUpgrade.unlockedPlot3;

        sliderMultiplier1 = buyUpgrade.sliderIncrease[0].multiplier;
        sliderMultiplier2 = buyUpgrade.sliderIncrease[1].multiplier;
        sliderMultiplier3 = buyUpgrade.sliderIncrease[2].multiplier;
        sliderMultiplier4 = buyUpgrade.sliderIncrease[3].multiplier;


        #region Plots Data

        amountPerClick1 = buyUpgrade.plots[0].amountPerClick;
        amountPerClick2 = buyUpgrade.plots[1].amountPerClick;
        amountPerClick3 = buyUpgrade.plots[2].amountPerClick;
        amountPerClick4 = buyUpgrade.plots[3].amountPerClick;

        clickPower1 = buyUpgrade.plots[0].clickPower;
        clickPower2 = buyUpgrade.plots[1].clickPower;
        clickPower3 = buyUpgrade.plots[2].clickPower;
        clickPower4 = buyUpgrade.plots[3].clickPower;

        sliderMulUpgradeValue1 = buyUpgrade.plots[0].sliderMulUpgradeValue;
        sliderMulUpgradeValue2 = buyUpgrade.plots[1].sliderMulUpgradeValue;
        sliderMulUpgradeValue3 = buyUpgrade.plots[2].sliderMulUpgradeValue;
        sliderMulUpgradeValue4 = buyUpgrade.plots[3].sliderMulUpgradeValue;

        perClickUpgradeValue1 = buyUpgrade.plots[0].perClickUpgradeValue;
        perClickUpgradeValue2 = buyUpgrade.plots[1].perClickUpgradeValue;
        perClickUpgradeValue3 = buyUpgrade.plots[2].perClickUpgradeValue;
        perClickUpgradeValue4 = buyUpgrade.plots[3].perClickUpgradeValue;

        clickPowerUpgradeValue1 = buyUpgrade.plots[0].clickPowerUpgradeValue;
        clickPowerUpgradeValue2 = buyUpgrade.plots[1].clickPowerUpgradeValue;
        clickPowerUpgradeValue3 = buyUpgrade.plots[2].clickPowerUpgradeValue;
        clickPowerUpgradeValue4 = buyUpgrade.plots[3].clickPowerUpgradeValue;


    #endregion


}

    //This does unfortunately not work
    //Goes through each plot and saves all the values respectively
    //for(int i = 0; i < buyUpgrade.plots.Length; i++)
    //{
    //    amountPerClick[i] = buyUpgrade.plots[i].amountPerClick;
    //    clickPower[i] = buyUpgrade.plots[i].clickPower;
    //    sliderMulUpgradeValue[i] = buyUpgrade.plots[i].sliderMulUpgradeValue;
    //    perClickUpgradeValue[i] = buyUpgrade.plots[i].perClickUpgradeValue;
    //    clickPowerUpgradeValue[i] = buyUpgrade.plots[i].clickPowerUpgradeValue;
    //}



}
