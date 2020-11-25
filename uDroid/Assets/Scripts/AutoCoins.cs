using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCoins : MonoBehaviour
{
    public bool creatingCoin = false;
    public static double coinIncrease = 1;
    public double internalIncrease;

    private void Update()
    {
        internalIncrease = coinIncrease;
        if(!creatingCoin)
        {
            creatingCoin = true;
            StartCoroutine(CreateCoin());
        }
    }

    IEnumerator CreateCoin()
    {
        GlobalCoins.CoinCount += internalIncrease;
        yield return new WaitForSeconds(1);
        creatingCoin = false;
    }
}
