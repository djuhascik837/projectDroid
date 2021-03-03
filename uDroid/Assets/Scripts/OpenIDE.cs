using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;
    private CanvasGroup testPanel;
    private CanvasGroup levelOne;
    public Text text;
    public Text textInput;
    public GameObject[] panels;
    private bool isAnimOpen;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");

            foreach (var panel in panels)
            {
                if (isOpen) panel.SetActive(false);
            }

            anim.SetBool("open", !isOpen);
            isAnimOpen = isOpen;
        } else
        {
            Debug.LogWarning("Anim == null");
        }
    }

    public void SelectRandomChallenge()
    {
        Debug.Log("starting Random Challenge");

        string idePanel = "IDE - Panel";
        string tester = "TextEditor - Panel";
        string level1 = "Level 1 - Basic If";
        string ideEditor = "IDE Editor - Input Field";

        testPanel = GameObject.Find(idePanel).transform.Find(tester).GetComponent<CanvasGroup>();
        levelOne = GameObject.Find(idePanel).transform.Find(level1).GetComponent<CanvasGroup>();
        InputField testerField = GameObject.Find(idePanel).transform.Find(tester).Find(ideEditor).GetComponent<InputField>();
        InputField level1Field = GameObject.Find(idePanel).transform.Find(level1).Find(ideEditor).GetComponent<InputField>();

        bool test = false;

        if (test)
        {
            if(!isAnimOpen)
            {
                foreach (var panel in panels)
                {
                    if (panel.name.Equals(tester)) panel.SetActive(true);
                }
            }

            GameController.input = testerField;

            text.text = "Test for IDE Panel Tester";
            textInput.text = "\"Test me\"";

            if (testPanel.alpha != 0)
            {
                testPanel.alpha = 0;
            }
            else if (testPanel.alpha != 1)
            {
                testPanel.alpha = 1;
            }
            else
            {
                Debug.LogWarning("Not 0 or 1");
            }
        } else
        {
            if (!isAnimOpen)
            {
                foreach (var panel in panels)
                {
                    if (panel.name.Equals(level1)) panel.SetActive(true);
                }
            }

            GameController.input = level1Field;

            text.text = "Test for Level 1 Basic if";
            textInput.text = "\"Test me 2\"";

            if (levelOne.alpha != 0)
            {
                levelOne.alpha = 0;
            }
            else if (levelOne.alpha != 1)
            {
                levelOne.alpha = 1;
            }
            else
            {
                Debug.LogWarning("Not 0 or 1");
            }
        }
    }
}
