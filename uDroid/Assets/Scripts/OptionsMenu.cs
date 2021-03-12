using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    public void SetVisible(bool hide)
    {
        print(hide);
        if(hide)
        {
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
        }
    }
}
