﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderIncrease : MonoBehaviour
{
    public Slider sld;
    public Text displayText;
    public float multiplier = 0.153f;
    private bool update = false;
    public AudioSource playSelectOn;
    public AudioSource playSelectOff;

    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void execute()
    {
        //tells update to start on button
        update = true;
        playSelectOn.Play();
    }

    void Update()
    {
        //check if update should be running
        if (update == true)
        {
            
            //check if slider is == null
            if (sld != null)
            {
                
                //increment the slider progress
                sld.value += multiplier;

                //check if slider has reached the end
                if (sld.value >= 1)
                {
                    //change button text, slider value and stop updating
                    SetText("Run Script");
                    sld.value = 0;
                    update = false;
                    playSelectOff.Play();
                    GlobalCoins.CoinCount += 1;
                }

                //display progress bar percentages
                displayText.text = Mathf.RoundToInt(sld.value * 100).ToString() + "%";
            }
            else
            {
                Debug.LogError("sld == null");
            }
        }
    }
}
