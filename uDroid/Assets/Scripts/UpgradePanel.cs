using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        //Toggles panel
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
}
