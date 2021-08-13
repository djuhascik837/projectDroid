using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderIncrease : MonoBehaviour
{
    public Slider sld;
    public Text displayText;
    public double multiplier = 0.07f;
    private bool update = false;
    public AudioSource playSelectOn;
    public AudioSource playSelectOff;
    public Plots plot;
    public GameObject img;
    public Texture textureON;
    public Texture textureIDLE;
    public ParticleSystem particleSystem0, particleSystem1;
    public BuyUpgrade buyUpgrade;

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

    public void ToggleParticleOn()
    {
        if (!particleSystem0.isPlaying)
        {
            particleSystem0.Play();
            particleSystem1.Play();
        }

    }

    public void ToggleParticleOff()
    {
        if (particleSystem0.isPlaying)
        {
            particleSystem0.Stop();
            particleSystem1.Stop();
        }
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
                sld.value += (float)multiplier;
                img.GetComponent<RawImage>().texture = textureON;
                ToggleParticleOn();

                //check if slider has reached the end
                if (sld.value >= 1)
                {
                    //change button text, slider value and stop updating
                    SetText("Run Script");
                    img.GetComponent<RawImage>().texture = textureIDLE;
                    ToggleParticleOff();
                    sld.value = 0;
                    update = false;
                    playSelectOff.Play();
                    buyUpgrade.currentCoins += plot.amountPerClick;
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
