using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoins : MonoBehaviour
{
    public static double CoinCount;
    public GameObject CoinDisplay;
    public double InternalCoins;

    void Update()
    {
        InternalCoins = CoinCount;
        CoinDisplay.GetComponent<Text>().text = "Coins: " + InternalCoins;
    }
}
