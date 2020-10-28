using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonClick : MonoBehaviour
{
    public GameObject textbox;

    public void ClickButton()
    {
        GlobalCookies.CookieCount += 1;
    }
}
