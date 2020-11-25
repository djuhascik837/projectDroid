using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public UpgradePanel upgradePanel;
    public ProgressBar fillBar;
    public GameObject statusText;
    public GameObject statusBox;
    public GameObject AutoCoin;

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
        if (GlobalCoins.CoinCount == 0)
        {
            statusBox.SetActive(true);
            statusText.GetComponent<Text>().text = "Not enough coins to purchase upgrade.";
            yield return new WaitForSeconds(0.5f);
            statusBox.GetComponent<Animation>().Play("StatusAnim");
            yield return new WaitForSeconds(0.8f);
            statusBox.SetActive(false);

        }
        else
        {
            GlobalCoins.CoinCount -= 1;
            StartAutoCoin();
        }
    }

    public void StartAutoCoin()
    {
        AutoCoin.SetActive(true);
        fillBar.start = true;
    }
}
