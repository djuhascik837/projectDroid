using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonClick : MonoBehaviour
{
    public GameObject textbox;
    public ProgressBar fillBar;

    public void ClickButton()
    {
        GlobalCookies.CookieCount += 1;
        fillBar.start = true;
    }
}
