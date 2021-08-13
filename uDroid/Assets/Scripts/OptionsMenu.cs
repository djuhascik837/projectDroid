using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject[] runScriptParticles;

    public void SetVisible(bool hide)
    {
        if(hide)
        {
            optionsMenu.SetActive(true);

            foreach (var particle in runScriptParticles)
            {
                particle.SetActive(false);
            }
        }
        else
        {
            optionsMenu.SetActive(false);

            foreach (var particle in runScriptParticles)
            {
                particle.SetActive(true);
            }
        }
    }
}
