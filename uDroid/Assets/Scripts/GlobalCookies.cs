using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
    public static int CookieCount;
    public GameObject CookieDisplay;
    public int InternalCookie;

    void Update()
    {
        InternalCookie = CookieCount;
        CookieDisplay.GetComponent<Text>().text = "Cookies: " + InternalCookie;
    }

    
}
