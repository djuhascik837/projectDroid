using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;
    private CanvasGroup testPanel;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
        } else
        {
            Debug.LogWarning("Anim == null");
        }
    }

    public void SelectRandomChallenge()
    {
        Debug.Log("starting Random Challenge");

        testPanel = GameObject.Find("IDE - Panel").transform.Find("TextEditor - Panel").GetComponent<CanvasGroup>();

        if (testPanel.alpha != 0)
        {
            testPanel.alpha = 0;
        }
        else if (testPanel.alpha != 1)
        {
            testPanel.alpha = 1;
        } else
        {
            Debug.LogWarning("Not 0 or 1");
        }
    }
}
