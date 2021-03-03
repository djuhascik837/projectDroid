﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCoins : MonoBehaviour
{
    public bool creatingCoin = false;
    public double coinIncrease = 1;
    public double internalIncrease;
    public float seconds = 1f;

    private void Update()
    {
        coinIncrease = BuyUpgrade.coinsPerDroid;
        internalIncrease = coinIncrease;
        //if coin is being created don't start creating another
        if(!creatingCoin)
        {
            creatingCoin = true;
            StartCoroutine(CreateCoin());
        }
    }

    IEnumerator CreateCoin()
    { 
        GlobalCoins.CoinCount += internalIncrease;
        yield return new WaitForSeconds(seconds);
        creatingCoin = false;
    }
}
