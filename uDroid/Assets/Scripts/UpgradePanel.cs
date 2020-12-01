using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject upgradeCoin;
    public GameObject upgradeCoinText;
    public GameObject upgradeSlider;
    public GameObject upgradeSliderText;

    public void OpenPanel()
    {
        //Toggles panel
        if (panel != null)
        {
            panel.SetActive(true);
            upgradeCoin.SetActive(true);
            upgradeSlider.SetActive(true);
        }
    }
}
