using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartHints : MonoBehaviour
{
    public static string messageToDisplay;
    public GameObject hintsPanel;

    public void DisplayHint()
    {
        print("Hints: " + messageToDisplay);

        Text msgText = hintsPanel.GetComponentInChildren<Text>();

        Animator anim = hintsPanel.GetComponent<Animator>();
        if (anim)
        {
            if (!string.IsNullOrEmpty(messageToDisplay))
            {
                if (msgText)
                {
                    anim.Play("Hints Open");
                    msgText.text = messageToDisplay;
                }
            }
        }
    }
}
