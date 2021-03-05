using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoins : MonoBehaviour
{
    public static double CoinCount;
    public GameObject[] CoinDisplay;
    public double InternalCoins;

    public void RoundCoins(double internalCoins)
    {
        if (InternalCoins >= 1000000000000000)
        {
            CoinDisplay[0].GetComponent<Text>().text = (InternalCoins / 1000000000000000).ToString("0.#") + "Q";
            CoinDisplay[1].GetComponent<Text>().text = (InternalCoins / 1000000000000000).ToString("0.#") + "Q";
        }
        else if (InternalCoins >= 1000000000000)
        {
            CoinDisplay[0].GetComponent<Text>().text = (InternalCoins / 1000000000000).ToString("0.#") + "T";
            CoinDisplay[1].GetComponent<Text>().text = (InternalCoins / 1000000000000).ToString("0.#") + "T";
        }
        else if (InternalCoins >= 1000000000)
        {
            CoinDisplay[0].GetComponent<Text>().text = (InternalCoins / 1000000000).ToString("0.#") + "B";
            CoinDisplay[1].GetComponent<Text>().text = (InternalCoins / 1000000000).ToString("0.#") + "B";
        }
        else if (InternalCoins >= 1000000)
        {
            CoinDisplay[0].GetComponent<Text>().text = (InternalCoins / 1000000).ToString("0.#") + "M";
            CoinDisplay[1].GetComponent<Text>().text = (InternalCoins / 1000000).ToString("0.#") + "M";
        }
        else if (InternalCoins >= 10000)
        {
            CoinDisplay[0].GetComponent<Text>().text = (InternalCoins / 1000).ToString("0.#") + "K";
            CoinDisplay[1].GetComponent<Text>().text = (InternalCoins / 1000).ToString("0.#") + "K";
        }
        else
        {
            CoinDisplay[0].GetComponent<Text>().text = InternalCoins.ToString("0.#");
            CoinDisplay[1].GetComponent<Text>().text = InternalCoins.ToString("0.#");
        }
    }

    void Update()
    {
        InternalCoins = Mathf.Round((float)CoinCount);
        RoundCoins(InternalCoins);
         
    }
}
