using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject upgradeCoin;
    public GameObject upgradeCoinText;
    public GameObject upgradeCoinIncrease;
    public GameObject upgradeCoinIncreaseText;
    public GameObject upgradeSlider;
    public GameObject upgradeSliderText;
    public GameObject upgradeClick;
    public GameObject upgradeClickText;
    public GameObject upgradeCLickMultiplier;
    public GameObject upgradeCLickMultiplierText;
    public GameObject upgradeCLickCoinGeneration;
    public GameObject upgradeCLickCoinGenerationText;

    //public void OpenPanel()
    //{
    //    //Toggles panel
    //    if (panel != null)
    //    {
    //        panel.SetActive(true);
    //        upgradeCoin.SetActive(true);
    //        upgradeSlider.SetActive(true);
    //    }
    //}

    public void StartOpenAnim()
    {
        Animator anim = panel.GetComponent<Animator>();
        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
        }
    }
}
