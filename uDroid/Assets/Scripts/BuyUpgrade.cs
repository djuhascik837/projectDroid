using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    public UpgradePanel upgradePanel;

    public void ClickButton()
    {
        
        GlobalCookies.CookieCount -= 1;
        if (upgradePanel != null)
        {
            bool isActive = upgradePanel.panel.activeSelf;
            upgradePanel.panel.SetActive(!isActive);
        }
    }
}
