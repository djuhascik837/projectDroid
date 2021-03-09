using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public double coins;
    public string test;

    public PlayerData(GlobalCoins globalCoins)
    {
        coins = GlobalCoins.CoinCount;
    }



}
